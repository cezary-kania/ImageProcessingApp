   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   8    2ImageProcessingApp.Views.ObjectSegmentationWindow2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  Objects segmentation��5   	   $	��335��6&   $	��554��63    � 
ResizeMode$ CanMinimize=�6?   .��5	      � .+�5
   
   �� -   5         ��Name$ lower_label��5
      $��Lower boundary:��6%   $
��Left=�6?   $��	38,23,0,0q�6Z   $	��Top=�6m   �� 5   
   -   5        $ lowerR_label��5      $��R:��6&   $
��Left=�63   $��	37,54,0,0q�6N   $	��Top=�6a   �� 5   
   -   5         ��Name$ lowerRTB��5      $
��Left=�6$   $��	62,58,0,0q�6?    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $��50��6~   6�   �� 5   
   -   5        $ lowerG_label��5      $��G:��6&   $
��Left=�63   $��
125,54,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ lowerGTB��5      $
��Left=�6$   $��
150,58,0,0q�6?   $
 Wrap=�6S   $	��Top=�6g   $��50��6   6�   �� 5   
   -   5        $ lowerB_label��5      $��B:��6&   $
��Left=�63   $��
215,54,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ lowerBTB��5      $
��Left=�6$   $��
240,58,0,0q�6?   $
 Wrap=�6S   $	��Top=�6g   $��50��6   6�   �� 5   
   -   5        $ Upper_label��5      $��Upper boundary:��6%   $
��Left=�6?   $��
42,103,0,0q�6Z   $	��Top=�6n   �� 5   
   -	   5        $ upperR_label��5      $��R:��6&   $
��Left=�63   $��
41,134,0,0q�6N   $	��Top=�6b   �� 5   
   -
   5        $ upperRTB��5      $
��Left=�6$   $��
66,138,0,0q�6?   $
 Wrap=�6S   $	��Top=�6g   $��50��6   6�   �� 5   
   -   5        $ upperG_label��5      $��G:��6&   $
��Left=�63   $��129,134,0,0q�6N   $	��Top=�6c   �� 5   
   -   5        $ upperGTB��5      $
��Left=�6$   $��154,138,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $��50��6�   6�   �� 5   
   -   5        $ upperB_label��5      $��B:��6&   $
��Left=�63   $��219,134,0,0q�6N   $	��Top=�6c   �� 5   
   -   5        $ upperBTB��5      $
��Left=�6$   $��244,138,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $��50��6�   6�   �� 5!   
   -   5        $ objsCounterLB��5!      $��Right=�6'   $��	0,10,70,0q�6C   $	��Top=�6V   �� 5"   
   -   5         ��Name$ preview_image��5"      $��Right=�6'   $	��200��6C   $	��200��6P   $��	0,50,20,0q�6\   $	��Top=�6o   $	��400��6�   �� 5#   
   -   5         ��Name$ 	CancelBtn��5#      $��Cancel��6$   $
��Left=�65   $��
25,255,0,0q�6P   $	��Top=�6d   $��54��6�   �� 5$   
   -   5        $ ApplyBtn��5$      $��Apply��6#   $
��Left=�63   $��
93,255,0,0q�6N   $	��Top=�6b   $��49��6�   �� 5%   
   -   5        $ SaveToFileBtn��5%      $��Save to file��6(   $
��Left=�6?   $��219,255,0,0q�6Z   $	��Top=�6o   $��84��6�   �� 5&   
   -   5        $ SaveBtn��5&      $
��Save��6"   $
��Left=�61   $��154,255,0,0q�6L   $	��Top=�6a   $��50��6y   6�   5'      5(      