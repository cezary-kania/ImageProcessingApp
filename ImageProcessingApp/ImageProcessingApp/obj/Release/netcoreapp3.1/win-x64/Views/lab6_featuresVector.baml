   M S B A M L   `   `   `  ���� M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  2    ,ImageProcessingApp.Views.lab6_featuresVector   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:ImageProcessingApp.Views       � Title$  lab6_featuresVector��$	��450��$	��800�� � 
ResizeMode$ CanMinimize=�.��� .+��� -    ��Name$ preview_image��$	��224��$��47,37,307,173q�$	��372���� -    ��Name$ 
Cancel_Btn��$��Cancel��$
��Left=�$��346,352,0,0q�$	��Top=�$��54��$��24���� -   $ FindvBtn��$��Find features vector��$
��Left=�$��220,352,0,0q�$	��Top=�$	��121��$��24���� -    ��Name$ notBinaryLB��$��Not binary image!��$
��Left=�$��132,105,0,0q�$	��Top=� J� RenderTransformOrigin$ 
0.495,0.37&�$y�Hidden=�&   System.Windows.Controls.DataGrid  -     Name$ 	VFeatures��$
��Left=�$	��251��   AutoGenerateColumns$ False��$��	549,0,0,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Feature��
   MinWidth$	
 125Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ feature�  $	 Value��$	
 120Q� �� $ value��� -    ��Name$ 	ContourCB��$
��Left=�$��
95,353,0,0q�$	��Top=�$	��120��