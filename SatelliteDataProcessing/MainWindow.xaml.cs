﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Galileo;

namespace SatelliteDataProcessing
{
  
    public partial class MainWindow : Window
    {
        LinkedList<double> sensorA = new LinkedList<double>();
        LinkedList<double> sensorB = new LinkedList<double>();
        
        public MainWindow()
        {
            InitializeComponent();
        }


        // Methods
        #region

        // Load Method
        private void LoadData()
        {
            // Clears both sensors and list boxes
            sensorA.Clear();
            sensorB.Clear();
            lstboxSensorA.Items.Clear();
            lstboxSensorB.Items.Clear();

            // intialzation
;           ReadData readData = new ReadData();
            int maxDataSize = 400;

            // get value from the integer updown controls
            double sigma = (double)upDownSigma.Value;
            double mu = (double)upDownMu.Value;

            // Adds data to both sensors
            for(int i = 0; i < maxDataSize; i++)
            {
                sensorA.AddFirst(readData.SensorA(mu, sigma));
                sensorB.AddFirst(readData.SensorB(mu, sigma));

            }
        }

        // ShowSensorData Method - splits each linkedList into a list view with headers
        private void ShowSensorData()
        {
            lvSensorData.Items.Clear();
            // Splits data into its section of the listview
            var dataList = sensorA.Zip(sensorB, (a, b) => new { sensorA = a, sensorB = b }).ToList();

            foreach(var data in dataList)
            {
                lvSensorData.Items.Add(data);
            }
        }

        // Number of Nodes Method - gets number of elements in a sensor
        private int NumberOfNodes(LinkedList<double> sensor)
        {
            return sensor.Count;
        }

        // DisplayListBoxData Method - Displays the sensor data into their listboxes
        private void DisplayListBoxData(LinkedList<double> sensor, ListBox listBoxName)
        {
            listBoxName.Items.Clear();
            foreach(var data in sensor)
            {
                listBoxName.Items.Add(data);
            }
          
        }

        // SelectionSort Method - Does a selection sort on a sensor
        private bool SelectionSort(LinkedList<double> sensor)
        {
            if (sensor == null)
            {
                return false; // returns false if the sensor is invalid
            }

            if (NumberOfNodes(sensor) <= 1)
            {
                return false; // returns false if sorting is not needed
            }

            for (int i = 0; i < NumberOfNodes(sensor) - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < NumberOfNodes(sensor); j++)
                {
                    if (sensor.ElementAt(j) < sensor.ElementAt(min))
                    {
                        min = j;
                    }
                }
                LinkedListNode<double> currentMin = sensor.Find(sensor.ElementAt(min));
                LinkedListNode<double> currentI = sensor.Find(sensor.ElementAt(i));

                double temp = currentMin.Value;
                currentMin.Value = currentI.Value;
                currentI.Value = temp;
            }

            return true; // indicates that the sort was successful
        }

        // InsertionSort Method - Does an Insertion Sort on a sensor
        private bool InsertionSort(LinkedList<double> sensor)
        {
            if (sensor == null)
            {
                return false; // returns false if the sensor is invalid
            }

            if (NumberOfNodes(sensor) <= 1)
            {
                return false; // returns false if sorting is not needed
            }
            for (int i = 0; i < NumberOfNodes(sensor) - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (sensor.ElementAt(j - 1) > sensor.ElementAt(j))
                    {
                        LinkedListNode<double> current = sensor.Find(sensor.ElementAt(j));
                        LinkedListNode<double> previous = sensor.Find(sensor.ElementAt(j - 1));

                        sensor.Remove(current);
                        sensor.AddBefore(previous, current.Value);
                    }
                }
            }
            return true; // indicates that the sort was successful
        }

        // BinarySearchIterative Method - Does an Iterative binary search on a sensor
        private int BinarySearchIterative(LinkedList<double> sensor, int searchValue)
        {
            int minimum = 0;
            int maximum = sensor.Count - 1;

            // check if list is sorted
            if (isSorted(sensor) == false)
            {
                MessageBox.Show("Lists are not sorted");
                return -1;
            }
            else
            {
                // performs search
                while (minimum <= maximum - 1)
                {
                    int middle = (minimum + maximum) / 2;
                    if (searchValue == sensor.ElementAt(middle))
                    {
                        return ++middle;
                    }
                    else if (searchValue < sensor.ElementAt(middle))
                    {
                        maximum = middle - 1;
                    }
                    else
                    {
                        minimum = middle + 1;
                    }
                }
                return minimum;
            }
        }

        // BinarySearchRecursive Method - Does a recursive binary search on a sensor
        private int BinarySearchRecursive(LinkedList<double> sensor, int searchValue, int minimum, int maximum)
        {
            if (isSorted(sensor) == false)
            {
                MessageBox.Show("List is not sorted");
                return -1;
            }
            else
            {
                if (minimum <= maximum - 1)
                {
                    int middle = (minimum + maximum) / 2;

                    if (searchValue == sensor.ElementAt(middle))
                    {
                        return middle;
                    }
                    else if (searchValue < sensor.ElementAt(middle))
                    {
                        return BinarySearchRecursive(sensor, searchValue, minimum, middle - 1);
                    }
                    else
                    {
                        return BinarySearchRecursive(sensor, searchValue, middle + 1, maximum);
                    }
                }
            }
            return minimum;
        }
       

        // HighlightItemsInListBox Method - Highlights the search target for the searches and highlights 1 item above and below the target
        private void HighlightItemsInListBox(LinkedList<double> sensor, ListBox listBox, int selectedIndex)
        {
            listBox.Items.Clear();

            for (int i = 0; i < sensor.Count; i++)
            {
                
                ListBoxItem item = new ListBoxItem();
                item.Content = sensor.ElementAt(i);

                if (i == selectedIndex - 2 || i == selectedIndex - 1 || i == selectedIndex || i == selectedIndex + 1 || i == selectedIndex + 2)
                {
                    item.Background = Brushes.LightBlue; // Highlight the items
                }

                listBox.Items.Add(item);
            }
            listBox.ScrollIntoView(listBox.Items[selectedIndex]);
        }

        // IsSorted Method - Checks if the sensor list is sorted
        private bool isSorted(LinkedList<double> sensor)
        {
            if (sensor.Count < 2)
            {
                return true;
            }
            double previousValue = sensor.First.Value;
            foreach(double value in sensor)
            {
                if (value < previousValue)
                {
                    return false;
                }
                previousValue = value;
            }
            return true;
        }
        // Search Textbox limiter - limits the text to only numeric values for the search target
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        // Clear all text boxes Method
        private void ClearTextBoxes()
        {
            stopWatchSensorAIterative.Clear();
            stopWatchSensorARecursive.Clear();
            txtBoxASearchTarget.Clear();
            stopWatchSensorASelection.Clear();
            stopWatchSensorAInsertion.Clear();

            stopWatchSensorBIterative.Clear();
            stopWatchSensorBRecursive.Clear();
            txtBoxBSearchTarget.Clear();
            stopWatchSensorBSelection.Clear();
            stopWatchSensorBInsertion.Clear();
        }
        #endregion

        // Buttons
        #region
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            LoadData();
            ShowSensorData();
            
        }
        // Sensor A Sorts
        #region
        private void btnSensorASelectionSort_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch(); // creates stopwatch instance
            sw.Start(); // starts the stop watch

            SelectionSort(sensorA);

            sw.Stop(); // stops the stopwatch
            stopWatchSensorASelection.Text = $"{sw.ElapsedMilliseconds} milliseconds"; // displays stop watch elapsed time in milliseconds

            isSorted(sensorA);
            DisplayListBoxData(sensorA, lstboxSensorA);
            
        }

        private void btnSensorAInsertionSort_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch(); // creates stopwatch instance
            sw.Start(); // starts the stop watch

            InsertionSort(sensorA);

            sw.Stop(); // stops the stopwatch
            stopWatchSensorAInsertion.Text = $"{sw.ElapsedMilliseconds} milliseconds"; // displays stop watch elapsed time in milliseconds

            isSorted(sensorA);
            DisplayListBoxData(sensorA, lstboxSensorA);
        }
        #endregion

        // Sensor B Sorts
        #region
        private void btnSensorBSelectionSort_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch(); // creates stopwatch instance
            sw.Start(); // starts the stop watch

            SelectionSort(sensorB);

            sw.Stop(); // stops the stopwatch
            stopWatchSensorBSelection.Text = $"{sw.ElapsedMilliseconds} milliseconds"; // displays stop watch elapsed time in milliseconds

            isSorted(sensorB);
            DisplayListBoxData(sensorB, lstboxSensorB);
        }

        private void btnSensorBInsertionSort_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch(); // creates stopwatch instance
            sw.Start(); // starts the stop watch

            InsertionSort(sensorB);

            sw.Stop(); // stops the stopwatch
            stopWatchSensorBInsertion.Text = $"{sw.ElapsedMilliseconds} milliseconds"; // displays stop watch elapsed time in milliseconds

            isSorted(sensorB);
            DisplayListBoxData(sensorB, lstboxSensorB);
        }
        #endregion

        // Sensor A Searches
        #region
        private void btnSensorABinaryI_Click(object sender, RoutedEventArgs e)
        {
           
            Stopwatch sw = new Stopwatch(); // makes stopwatch instance
            sw.Start(); // starts stopwatch

            int searchValue;
            int.TryParse(txtBoxASearchTarget.Text, out searchValue);
            int position = BinarySearchIterative(sensorA, searchValue);

            if (position > 0 && position <= sensorA.Count)
            {
                sw.Stop(); // stops the stopwatch
                HighlightItemsInListBox(sensorA, lstboxSensorA, position);
                stopWatchSensorAIterative.Text = $"{sw.ElapsedTicks} ticks"; // displays elapsed time from stopwatch in ticks
            }
           
        }

        private void btnSensorABinaryR_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch(); // makes stopwatch instance
            sw.Start(); // starts stopwatch
            
            int searchValue;
            int.TryParse(txtBoxASearchTarget.Text, out searchValue);
            int minimum = 0;
            int maximum = sensorA.Count - 1;
            
            int result = BinarySearchRecursive(sensorA, searchValue, minimum, maximum);
            if (result > 0 && result <= sensorA.Count)
            {
                sw.Stop(); // stops the stopwatch
                HighlightItemsInListBox(sensorA, lstboxSensorA, result);
                stopWatchSensorARecursive.Text = $"{sw.ElapsedTicks} ticks"; // displays elapsed time from stopwatch in ticks
            }
            else
            {
                sw.Stop();
            }
        }
        #endregion

        // Sensor B Searches
        #region
        private void btnSensorBBinaryI_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch(); // makes stopwatch instance
            sw.Start(); // starts stopwatch

            int searchValue;
            int.TryParse(txtBoxBSearchTarget.Text, out searchValue);
            int position = BinarySearchIterative(sensorB, searchValue);

            if (position > 0 && position <= sensorB.Count)
            {
                sw.Stop(); // stops the stopwatch
                HighlightItemsInListBox(sensorB, lstboxSensorB, position);
                stopWatchSensorBIterative.Text = $"{sw.ElapsedTicks} ticks"; // displays elapsed time from stopwatch in ticks
            }
        }
        private void btnSensorBBinaryR_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch(); // makes stopwatch instance
            sw.Start(); // starts stopwatch

            int searchValue;
            int.TryParse(txtBoxBSearchTarget.Text, out searchValue);
            int minimum = 0;
            int maximum = sensorB.Count - 1;

            int result = BinarySearchRecursive(sensorB, searchValue, minimum, maximum);
            if (result > 0 && result <= sensorB.Count)
            {
                sw.Stop(); // stops the stopwatch
                HighlightItemsInListBox(sensorB, lstboxSensorB, result);
                stopWatchSensorBRecursive.Text = $"{sw.ElapsedTicks} ticks"; // displays elapsed time from stopwatch in ticks
            }
            else
            {
                sw.Stop();
            }
        }

        #endregion

    }
}
#endregion