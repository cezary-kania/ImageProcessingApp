   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   <    6ImageProcessingApp.Views.MorphologicalOperationsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  Morphological Operations��5   	   $	��451��6+   $	��370��68    � 
ResizeMode$ CanMinimize=�6D   .��5	      � .+�5
   
   �� -   5         ��Name$ preview_image��5
      $��Center=�6'   $	��181��6D   $��	0,156,0,0q�6Q   $	��Top=�6d   $	��372��6|   �� 5   
   -   5         ��Name$ 
Cancel_Btn��5      $��Cancel��6%   $��Center=�66   $��	0,352,0,0q�6S   $	��Top=�6f   $��54��6~   $��24��6�   �� 5   
   -   5        $ ApplyBtn��5      $��Apply��6#   $
��Left=�63   $��283,352,0,0q�6N   $	��Top=�6c   $��54��6{   $��24��6�   �� 5   
   -   5         ��Name$ operationCB��5      $
��Left=�6(   $��
160,14,0,0q�6C   $	��Top=�6W   $	��120��6o   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��	65,15,0,0q�6B   $��
Operation:��6U   $
��Wrap=�6g   $	��Top=�6{   �� 5   
   -   5        $ 	elementCB��5      $
��Left=�6&   $��
160,44,0,0q�6A   $	��Top=�6U   $	��120��6m   �� 5   
   -   5        $ textBlock_Copy_1��5      $
��Left=�6.   $��	65,45,0,0q�6I   $��element:��6\   $
��Wrap=�6l   $	��Top=�6�   �� 5   
   -   5        $ 
BorderOpCB��5      $
��Left=�6'   $��
160,74,0,0q�6B   $	��Top=�6V   $	��120��6n   �� 5   
   -	   5        $ textBlock_Copy��5      $
��Left=�6,   $��	65,75,0,0q�6G   $��Border operation:��6Z   $
��Wrap=�6s   $	��Top=�6�   �� 5   
   -
   5        $ 
ExecuteBtn��5      $��Execute��6%   $
��Left=�67   $��220,352,0,0q�6R   $	��Top=�6g   $��54��6   $��24��6�   �� 5   
   -   5         ��Name$ notBinaryLB��5      $��Not binary image!��6%   $
��Left=�6A   $��132,105,0,0q�6\   $	��Top=�6q    J� RenderTransformOrigin$ 
0.495,0.37&�6�   $y�Hidden=�6�   �� 5   
   -   5        $ label��5      $��R:��6   $
��Left=�6,   $��
283,41,0,0q�6G   $	��Top=�6[   �� 5   
   -   5         ��Name$ radiusTB��5      $
��Left=�6$   $��
310,46,0,0q�6?   $��3��6S   	 �� TextWrapping$
	 Wrap=�6\   $	��Top=�6p   $��27��6�   6�   5      5      