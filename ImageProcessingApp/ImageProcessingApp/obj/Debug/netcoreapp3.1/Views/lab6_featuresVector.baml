   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   2    ,ImageProcessingApp.Views.lab6_featuresVector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  lab6_featuresVector��5   	   $	��450��6%   $	��800��62    � 
ResizeMode$ CanMinimize=�6>   .��5	      � .+�5
   
   �� -   5         ��Name$ preview_image��5
      $	��224��6'   $��47,37,307,173q�64   $	��372��6K   �� 5   
   -   5         ��Name$ 
Cancel_Btn��5      $��Cancel��6%   $
��Left=�66   $��346,352,0,0q�6Q   $	��Top=�6f   $��54��6~   $��24��6�   �� 5   
   -   5        $ FindvBtn��5      $��Find features vector��6#   $
��Left=�6B   $��220,352,0,0q�6]   $	��Top=�6r   $	��121��6�   $��24��6�   �� 5   
   -   5         ��Name$ notBinaryLB��5      $��Not binary image!��6%   $
��Left=�6A   $��132,105,0,0q�6\   $	��Top=�6q    J� RenderTransformOrigin$ 
0.495,0.37&�6�   $y�Hidden=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	VFeatures��5      $
��Left=�6&   $	��251��6A      AutoGenerateColumns$ False��6M   $��	549,0,0,0q�6i      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Feature��6%   
   MinWidth$	
 125Q�6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� Path$ feature�6W     5      $	 Value��6%   $	
 120Q�6S    64   �� $ value�6S   5      �� 5   
   -   5         ��Name$ 	ContourCB��5      $
��Left=�6&   $��
95,353,0,0q�6A   $	��Top=�6U   $	��120��6m   5      5      