   M S B A M L   `   `   `  ����R  NSatelliteDataProcessing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SatelliteDataProcessingSatelliteDataProcessing  5   	   (    "SatelliteDataProcessing.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:SatelliteDataProcessing     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  
MainWindow��5	   	   $	��562��6   $	��843��6)   .��5
      � $��	0,0,0,-16q�6   .+�5   
   %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5          Name$ upDownSigma��5      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Value 1062   $��
134,30,0,0q�6=   $��24��6Q   $	��Top=�6]   $
��Left=�6u   $��63��6�      Minimum 106�      Maximum 206�      DefaultValue 106�     5   
   -   5        $ upDownMu��5       506/   $��	56,30,0,0q�6:   $
��Left=�6M   $��65��6h   $��24��6s   $	��Top=�6    356�    756�    506�   �� 5   
   -   5         ��Name$ lvSensorData��5      $��
26,89,0,42q�6)   $
��Left=�6=   $	��241��6X    �� View 5      �� 5      .P�5      �� $��SensorA��6%    �� Width$	 120��66   	 �� DisplayMemberBinding	 6B   �� 
 �� Path$
 sensorA��� 5      $��SensorB��6%   $	 120��66   	 6B   �� $
 sensorB�5      5      �� 5   
   $��Button��6   $
��Left=�6"   $��1186,326,0,0q�6=   $	��Top=�6S   $��0��6k   �� 5   
   -   5         ��Name$ btnLoadData��5      $��	Load Data��6&   $
��Left=�6:   $��	92,64,0,0q�6U   $	��Top=�6h   $��72��6�   6�   �� 5   
   -   5        $ btnSensorABinaryI��5      $��Search��6,   $
��Left=�6=   $��
300,91,0,0q�6X   $	��Top=�6l   $��58��6�   6�   �� 5   
   -   5         ��Name$ lstboxSensorA��5      $��400,89,0,42q�6T   $
��Left=�6i   $	��109��6�    �� SelectionMode$ Multiple=�6�   �� 5   
   -   5        $ lstboxSensorB��5      $��656,89,0,42q�6T   $
��Left=�6i   $	��109��6�   $ Multiple=�6�   �� 5   
   $
��Left=�6   $��
400,10,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��44��6o   $	��125��6{   $��22(�6�   $��Britannic Bold)�6�   �� 6�   $
��Bold"�6�   $�SENSOR A��6�   6�   �� 5   
   $
��Left=�6   $��
656,10,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��44��6o   $	��125��6{   $��22(�6�   $��Britannic Bold)�6�   �� 6�   $
��Bold"�6�   $�SENSOR B��6�   6�   �� 5   
   $
��Left=�6   $��
300,45,0,0q�6/   $
��Wrap=�6C   $��Binary Search Iterative��6W   $	��Top=�6v   $��47��6�   $��75��6�   �� 5    
   $
��Left=�6   $��300,155,0,0q�6/   $
��Wrap=�6D   $��Binary Search Recursive��6X   $	��Top=�6w   $��33��6�   $��75��6�   �� 5!   
   -   5        $ btnSensorABinaryR��5!      $��Search��6,   $
��Left=�6=   $��300,193,0,0q�6X   $	��Top=�6m   $��58��6�   6�   �� 5"   
   -	   5         ��Name$ txtBoxASearchTarget��5"      $
��Left=�6S   $��300,291,0,0q�6n    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��53��6�   �� 5#   
   $
��Left=�6   $��300,246,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��33��6p   $��58��6|   �� 6�   $�Search Target��6�   �� 6�   �� 6�   6�   �� 5$   
   -
   5        $ btnSensorASelectionSort��5$      $
��Sort��62   $
��Left=�6A   $��300,377,0,0q�6\   $	��Top=�6q   $��58��6�   6�   �� 5%   
   -   5        $ btnSensorAInsertionSort��5%      $
��Sort��62   $
��Left=�6A   $��298,466,0,0q�6\   $	��Top=�6q   $��58��6�   6�   �� 5&   
   $
��Left=�6   $��300,329,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��33��6p   $��58��6|   �� 6�   $�Selection Sort��6�   �� 6�   �� 6�   6�   �� 5'   
   $
��Left=�6   $��300,422,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��33��6p   $��58��6|   �� 6�   $�Insertion Sort��6�   �� 6�   �� 6�   6�   �� 5(   
   -   5        $ stopWatchSensorASelection��5(      $
��Left=�65   $��272,402,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�    �� 
IsReadOnly$
 True��6�   �� 5)   
   -   5        $ stopWatchSensorAInsertion��5)      $
��Left=�65   $��272,491,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   $
 True��6�   �� 5*   
   -   5        $ stopWatchSensorAIterative��5*      $
��Left=�65   $��272,123,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   $
 True��6�   �� 5+   
   $
��Left=�6   $��
537,40,0,0q�6/   $
��Wrap=�6C   $��Binary Search Iterative��6W   $	��Top=�6v   $��47��6�   $��75��6�   �� 5,   
   -   5        $ btnSensorBBinaryI��5,      $��Search��6,   $
��Left=�6=   $��
545,92,0,0q�6X   $	��Top=�6l   $��58��6�   6�   �� 5-   
   -   5        $ stopWatchSensorBIterative��5-      $
��Left=�65   $��514,123,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 5.   
   $
��Left=�6   $��536,155,0,0q�6/   $
��Wrap=�6D   $��Binary Search Recursive��6X   $	��Top=�6w   $��33��6�   $��76��6�   �� 5/   
   -   5        $ btnSensorBBinaryR��5/      $��Search��6,   $
��Left=�6=   $��545,193,0,0q�6X   $	��Top=�6m   $��58��6�   6�   �� 50   
   $
��Left=�6   $��546,246,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��33��6p   $��58��6|   �� 6�   $�Search Target��6�   �� 6�   �� 6�   6�   �� 51   
   -   5        $ txtBoxBSearchTarget��51      $
��Left=�6S   $��548,291,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $��53��6�   �� 52   
   $
��Left=�6   $��545,329,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��33��6p   $��58��6|   �� 6�   $�Selection Sort��6�   �� 6�   �� 6�   6�   �� 53   
   -   5        $ btnSensorBSelectionSort��53      $
��Sort��62   $
��Left=�6A   $��543,377,0,0q�6\   $	��Top=�6q   $��58��6�   6�   �� 54   
   -   5        $ stopWatchSensorBSelection��54      $
��Left=�65   $��512,402,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 55   
   $
��Left=�6   $��543,422,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��33��6p   $��58��6|   �� 6�   $�Insertion Sort��6�   �� 6�   �� 6�   6�   �� 56   
   -   5        $ btnSensorBInsertionSort��56      $
��Sort��62   $
��Left=�6A   $��543,466,0,0q�6\   $	��Top=�6q   $��58��6�   6�   �� 57   
   -   5        $ stopWatchSensorBInsertion��57      $
��Left=�65   $��514,491,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 58   
   -   5        $ stopWatchSensorARecursive��58      $
��Left=�65   $��272,221,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   $
 True��6�   �� 59   
   -   5        $ stopWatchSensorBRecursive��59      $
��Left=�65   $��512,221,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 5:   
   $
��Left=�6   $��
134,10,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��20��6o   $��52��6{   $��Britannic Bold)�6�   $��Sigma��6�   �� 5;   
   $
��Left=�6   $��	56,10,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��20��6n   $��53��6z   $��Britannic Bold)�6�   $��Mu��6�   5>      5?      