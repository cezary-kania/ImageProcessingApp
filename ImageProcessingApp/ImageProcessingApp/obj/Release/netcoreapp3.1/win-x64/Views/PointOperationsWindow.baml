   M S B A M L   `   `   `  ���� M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  4    .ImageProcessingApp.Views.PointOperationsWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:ImageProcessingApp.Views       � Title$  PointOperationsWindow��$	��403��$	��625�� � 
ResizeMode$ CanMinimize=�.��� .+��� -    ��Name$ Image1ComboBox��$
��Left=�$��	48,80,0,0q�$	��Top=�$	��170�� �� SelectedIndex$ 3���� -   $ Image2ComboBox��$
��Left=�$��
48,143,0,0q�$	��Top=�$	��170��${�False���� -    ��Name$ label��$��Select two images:��$
��Left=�$��	47,16,0,0q�$	��Top=��� -   $ label1��$��Image 1:��$
��Left=�$��	47,54,0,0q�$	��Top=��� -   $ label1_Copy��$��Image 2:��$
��Left=�$��
47,112,0,0q�$	��Top=��� -   $ label1_Copy1��$��
Operation:��$
��Left=�$��
47,180,0,0q�$	��Top=��� -   $ OperationComboBox��$
��Left=�$��
48,215,0,0q�$	��Top=�$	��170���� -    ��Name$ button��$��Execute��$
��Left=�$��112,323,0,0q�$	��Top=�${�False���� -	   $ ApplyBtn��$��Apply��$
��Left=�$��183,323,0,0q�$	��Top=�${�False���� -
    ��Name$ preview_image��$��Right=�$	��181��$��
0,80,100,0q�$	��Top=�$	��200���� -   $ 	CancelBtn��$��Cancel��$
��Left=�$��
49,324,0,0q�$	��Top=��� -   $ AlphaLB��$��Alpha(0-1):��$
��Left=�$��
46,250,0,0q�$	��Top=�${�False���� -    ��Name$ AlphaTB��${�False��$
��Left=�$��163,254,0,0q�$	��0,5�� �� TextWrapping$
 Wrap=�$	��Top=�$��55���� -   $ label2��$��Preview:��$
��Left=�$��
291,16,0,0q�$	��Top=��� -   $ BetaLB��${�False��$��
Beta(0-1):��$
��Left=�$��
46,273,0,0q�$	��Top=��� -   $ BetaTB��${�False��$
��Left=�$��163,277,0,0q�$	��0,5��$
 Wrap=�$	��Top=�$��55���� -   $ GammaLB��${�False��$��Gamma:��$
��Left=�$��
46,294,0,0q�$	��Top=��� -   $ GammaTB��${�False��$
��Left=�$��163,298,0,0q�$��0��$
 Wrap=�$	��Top=�$��55��