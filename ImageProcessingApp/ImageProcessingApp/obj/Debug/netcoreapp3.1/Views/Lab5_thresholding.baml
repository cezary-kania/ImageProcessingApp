   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   0    *ImageProcessingApp.Views.Lab5_thresholding   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  Lab5_thresholding��5   	   $	��380��6#   $	��372��60    � 
ResizeMode$ CanMinimize=�6<   .��5	      � .+�5
   
   �� -   5         ��Name$ preview_image��5
      $��Center=�6'   $	��181��6D   $��	10,80,0,0q�6Q   $	��Top=�6d   $	��372��6|   �� 5   
   -   5         ��Name$ 
Cancel_Btn��5      $��Cancel��6%   $��Center=�66   $��	0,288,0,0q�6S   $	��Top=�6f   $��54��6~   $��24��6�   �� 5   
   -   5        $ ApplyBtn��5      $��Apply��6#   $
��Left=�63   $��283,288,0,0q�6N   $	��Top=�6c   $��54��6{   $��24��6�   �� 5   
   -   5         ��Name$ ThMethodComboBox��5      $
��Left=�6-   $��
160,14,0,0q�6H   $	��Top=�6\   $	��120��6t   6�   �� 5   
   -   5         ��Name$ 
ThMethodLB��5      $
��Left=�6(   $��	32,15,0,0q�6C   $��Thresholding method:��6V   $
��Wrap=�6r   $	��Top=�6�   �� 5   
   -   5        $
 ThLB��5      $
��Left=�6"   $��	92,45,0,0q�6=   $��
Threshold:��6P   $
��Wrap=�6b   $	��Top=�6v   �� 5   
   -   5        $ 
ExecuteBtn��5      $��Execute��6%   $
��Left=�67   $��220,288,0,0q�6R   $	��Top=�6g   $��54��6   $��24��6�   �� 5   
   -   5         ��Name$ ThresholdTB��5      $
��Left=�6'   $��
160,45,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��120��6�   6�   5      5      