   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   4    .ImageProcessingApp.Views.PointOperationsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  PointOperationsWindow��5   	   $	��403��6'   $	��625��64    � 
ResizeMode$ CanMinimize=�6@   .��5	      � .+�5
   
   �� -   5         ��Name$ Image1ComboBox��5
      $
��Left=�6+   $��	48,80,0,0q�6F   $	��Top=�6Y   $	��170��6q    �� SelectedIndex$ 3��6�   �� 5   
   -   5        $ Image2ComboBox��5      $
��Left=�6+   $��
48,143,0,0q�6F   $	��Top=�6Z   $	��170��6r   ${�False��6�   �� 5   
   -   5         ��Name$ label��5      $��Select two images:��6   $
��Left=�6<   $��	47,16,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ label1��5      $��Image 1:��6    $
��Left=�63   $��	47,54,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $ label1_Copy��5      $��Image 2:��6%   $
��Left=�68   $��
47,112,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ label1_Copy1��5      $��
Operation:��6&   $
��Left=�6;   $��
47,180,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ OperationComboBox��5      $
��Left=�6.   $��
48,215,0,0q�6I   $	��Top=�6]   $	��170��6u   6�   �� 5   
   -   5         ��Name$ button��5      $��Execute��6!   $
��Left=�63   $��112,323,0,0q�6N   $	��Top=�6c   ${�False��6�   �� 5   
   -	   5        $ ApplyBtn��5      $��Apply��6#   $
��Left=�63   $��183,323,0,0q�6N   $	��Top=�6c   ${�False��6�   �� 5   
   -
   5         ��Name$ preview_image��5      $��Right=�6'   $	��181��6C   $��
0,80,100,0q�6P   $	��Top=�6d   $	��200��6|   �� 5   
   -   5        $ 	CancelBtn��5      $��Cancel��6$   $
��Left=�65   $��
49,324,0,0q�6P   $	��Top=�6d   6|   �� 5   
   -   5        $ AlphaLB��5      $��Alpha(0-1):��6!   $
��Left=�67   $��
46,250,0,0q�6R   $	��Top=�6f   ${�False��6~   �� 5   
   -   5         ��Name$ AlphaTB��5      ${�False��6#   $
��Left=�65   $��163,254,0,0q�6P   $	��0,5��6e    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $��55��6�   6�   �� 5   
   -   5        $ label2��5      $��Preview:��6    $
��Left=�63   $��
291,16,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ BetaLB��5      ${�False��6    $��
Beta(0-1):��62   $
��Left=�6G   $��
46,273,0,0q�6b   $	��Top=�6v   �� 5   
   -   5        $ BetaTB��5      ${�False��6"   $
��Left=�64   $��163,277,0,0q�6O   $	��0,5��6d   $
 Wrap=�6o   $	��Top=�6�   $��55��6�   6�   �� 5   
   -   5        $ GammaLB��5      ${�False��6!   $��Gamma:��63   $
��Left=�6D   $��
46,294,0,0q�6_   $	��Top=�6s   �� 5   
   -   5        $ GammaTB��5      ${�False��6#   $
��Left=�65   $��163,298,0,0q�6P   $��0��6e   $
 Wrap=�6n   $	��Top=�6�   $��55��6�   6�   5      5      