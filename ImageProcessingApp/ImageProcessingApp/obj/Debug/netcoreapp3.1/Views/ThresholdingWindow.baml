   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   1    +ImageProcessingApp.Views.ThresholdingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	   -   5          � Title$  ThresholdingWindow��5   	   $	��380��6$   $	��372��61    � 
ResizeMode$ CanMinimize=�6=   .��5	      � .+�5
   
   �� -   5         ��Name$
 CB_2��5
      $0��*Thresholding with keeping luminance levels��6!   $
��Left=�6V   $��	32,46,0,0q�6q   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ ApplyBtn��5      $��Apply��6#   $
��Left=�63   $��283,288,0,0q�6N   $	��Top=�6c   $��54��6{   $��24��6�   �� 5   
   -   5         ��Name$ 	p1_slider��5      $
��Left=�6$   $��	57,14,0,0q�6?   $	��Top=�6R   $	��176��6j    �� IsSnapToTickEnabled$
 True��6�    �� TickFrequency$ 1Q�5      �� 5   
   -   5         ��Name$ p1_TB��5      $
��Left=�6!   $��
250,14,0,0q�6<    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $��64��6|   6�   �� 5   
   -   5        	 ��Name$	 p1_label��5      $��p1��6"   $
��Left=�6/   $��26,6,0,0q�6J   $	��Top=�6\   �� 5   
   -   5        
 ��Name$
 preview_image��5      $��Center=�6'   $	��181��6D   $��	10,80,0,0q�6Q   $	��Top=�6d   $	��372��6|   �� 5   
   -   5        $ 
Cancel_Btn��5      $��Cancel��6%   $
��Left=�66   $��217,288,0,0q�6Q   $	��Top=�6f   $��54��6~   $��24��6�   5      5      