   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   /    )ImageProcessingApp.Views.EdetectionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  Edge detection��5   	   $	��380��6    $	��372��6-    � 
ResizeMode$ CanMinimize=�69   .��5	      � .+�5
   
   �� -   5         ��Name$ preview_image��5
      $��Center=�6'   $	��181��6D   $��	10,80,0,0q�6Q   $	��Top=�6d   $	��372��6|   �� 5   
   -   5         ��Name$ 
Cancel_Btn��5      $��Cancel��6%   $��Center=�66   $��	0,288,0,0q�6S   $	��Top=�6f   $��54��6~   $��24��6�   �� 5   
   -   5        $ ApplyBtn��5      $��Apply��6#   $
��Left=�63   $��283,288,0,0q�6N   $	��Top=�6c   $��54��6{   $��24��6�   �� 5   
   -   5        $ 
ExecuteBtn��5      $��Execute��6%   $
��Left=�67   $��220,288,0,0q�6R   $	��Top=�6g   $��54��6   $��24��6�   �� 5   
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
   -	   5         ��Name$ th1_l��5      $��Th 1:��6   $
��Left=�6/   $��
260,13,0,0q�6J   $	��Top=�6^   �� 5   
   -
   5        $ th2_l��5      $��Th 2:��6   $
��Left=�6/   $��
260,41,0,0q�6J   $	��Top=�6^   �� 5   
   -   5         ��Name$ th1TB��5      $
��Left=�6!   $��
307,17,0,0q�6<   $�� ��6P    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $��62��6�   6�   �� 5   
   -   5        $ th2TB��5      $
��Left=�6!   $��
307,46,0,0q�6<   $�� ��6P   $
 Wrap=�6X   $	��Top=�6l   $��62��6�   6�   5      5      