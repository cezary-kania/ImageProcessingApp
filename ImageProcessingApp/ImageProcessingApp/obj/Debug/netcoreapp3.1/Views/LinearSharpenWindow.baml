   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   2    ,ImageProcessingApp.Views.LinearSharpenWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  LinearSharpenWindow��5   	   $	��362��6%   $	��522��62    � 
ResizeMode$ CanMinimize=�6>   .��5	      � .+�5
   
   �� -   5         ��Name$ preview_image��5
      $	��181��6'   $	��181��63   $��-180,80,0,0q�6@   $	��Top=�6U   $	��372��6m   �� 5   
   -   5         ��Name$ 
Cancel_Btn��5      $��Cancel��6%   $
��Left=�66   $��288,281,0,0q�6Q   $	��Top=�6f   $��54��6~   $��24��6�   �� 5   
   -   5        $ ApplyBtn��5      $��Apply��6#   $
��Left=�63   $��420,281,0,0q�6N   $	��Top=�6c   $��54��6{   $��24��6�   �� 5   
   -   5        $ 
ExecuteBtn��5      $��Execute��6%   $
��Left=�67   $��358,281,0,0q�6R   $	��Top=�6g   $��54��6   $��24��6�   �� 5   
   -   5         ��Name$ 
BorderOpCB��5      $
��Left=�6'   $��
127,44,0,0q�6B   $	��Top=�6V   $	��120��6n   �� 5   
   -   5         ��Name$ textBlock_Copy��5      $
��Left=�6,   $��	10,45,0,0q�6G   $��Borderoperation:��6Z   $
��Wrap=�6r   $	��Top=�6�   �� 5   
   -   5        $ maskCB��5      $
��Left=�6#   $��
127,14,0,0q�6>   $	��Top=�6R   $	��120��6j   6v   �� 5   
   -   5        $ 	textBlock��5      $
��Left=�6'   $��	13,15,0,0q�6B   $��Mask:��6U   $
��Wrap=�6b   $	��Top=�6v   �� 5   
   -	   5         ��Name$ m0��5      $
��Left=�6   $��346,126,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $��31��6z    �� 
IsReadOnly$
 True��6�   �� 5   
   -
   5        $ m1��5      $
��Left=�6   $��396,126,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        $ m2��5      $
��Left=�6   $��436,126,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        $ m3��5      $
��Left=�6   $��346,156,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        $ m4��5      $
��Left=�6   $��396,156,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        $ m5��5      $
��Left=�6   $��436,156,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        $ m6��5      $
��Left=�6   $��346,186,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        $ m7��5      $
��Left=�6   $��396,186,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        $ m8��5      $
��Left=�6   $��436,186,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��31��6z   $
 True��6�   �� 5   
   -   5        	 ��Name$	 label��5      $��Mask:��6   $
��Left=�6/   $��
344,89,0,0q�6J   $	��Top=�6^   5      5      