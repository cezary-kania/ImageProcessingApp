   M S B A M L   `   `   `  ���� M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  4    .ImageProcessingApp.Views.MaskConvolutionWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:ImageProcessingApp.Views       � Title$  MaskConvolutionWindow��$	��519��$	��670�� � 
ResizeMode$ CanMinimize=�.��� $��0,2,0,-2q�.+��� -    ��Name$ preview_image��$	��226��$��36,80,359,0q�$	��Top=�$	��372���� -    ��Name$ 
Cancel_Btn��$��Cancel��$
��Left=�$��440,430,0,0q�$	��Top=�$��54��$��24���� -   $ ApplyBtn��$��Apply��$
��Left=�$��572,430,0,0q�$	��Top=�$��54��$��24���� -   $ 
ExecuteBtn��$��Execute��$
��Left=�$��510,430,0,0q�$	��Top=�$��54��$��24���� -    ��Name$ 
BorderOpCB��$
��Left=�$��
258,45,0,0q�$	��Top=�$	��120���� -    ��Name$ textBlock_Copy��$
��Left=�$��
257,17,0,0q�$��Borderoperation:��$
��Wrap=�$	��Top=��� -   $ maskCB��$
��Left=�$��
127,14,0,0q�$	��Top=�$	��120���� -   $ 	textBlock��$
��Left=�$��	13,15,0,0q�$��Sharpen mask:��$
��Wrap=�$	��Top=��� -	    ��Name$ m0��$
��Left=�$��346,126,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��31�� �� 
IsReadOnly$
 True���� -
   $ m1��$
��Left=�$��396,126,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $ m2��$
��Left=�$��436,126,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $ m3��$
��Left=�$��346,156,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $ m4��$
��Left=�$��396,156,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $ m5��$
��Left=�$��436,156,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $ m6��$
��Left=�$��346,186,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $ m7��$
��Left=�$��396,186,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $ m8��$
��Left=�$��436,186,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   	 ��Name$	 label��$��Sharpen mask:��$
��Left=�$��
344,89,0,0q�$	��Top=��� -   $ blurringMaskCB��$
��Left=�$��
127,45,0,0q�$	��Top=�$	��120���� -   $ bluringMaskLabel��$
��Left=�$��	13,46,0,0q�$��Bluring mask:��$
��Wrap=�$	��Top=��� -   $
 m2_0��$
��Left=�$��494,126,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_1��$
��Left=�$��543,126,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_2��$
��Left=�$��583,126,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_3��$
��Left=�$��494,156,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_4��$
��Left=�$��543,156,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_5��$
��Left=�$��583,156,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_6��$
��Left=�$��494,186,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_7��$
��Left=�$��543,186,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $
 m2_8��$
��Left=�$��583,186,0,0q�$
 Wrap=�$	��Top=�$��31��$
 True���� -   $	 
label_Copy��$��Bluring mask:��$
��Left=�$��
489,89,0,0q�$	��Top=��� -   $	 label_Copy1��$��Result mask:��$
��Left=�$��382,223,0,0q�$	��Top=��� -    $
 m3_0��$
��Left=�$��398,260,0,0q�$
 Wrap=�$	��Top=�$��30��$
 True���� -!   $
 m3_1��$
��Left=�$��436,260,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -"   $
 m3_2��$
��Left=�$��476,260,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -#   $
 m3_3��$
��Left=�$��518,260,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -$   $
 m3_4��$
��Left=�$��558,260,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -%   $
 m3_5��$
��Left=�$��398,290,0,0q�$
 Wrap=�$	��Top=�$��30��$
 True���� -&   $
 m3_6��$
��Left=�$��436,290,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -'   $
 m3_7��$
��Left=�$��476,290,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -(   $ m3_10��$
��Left=�$��398,320,0,0q�$
 Wrap=�$	��Top=�$��30��$
 True���� -)   $ m3_11��$
��Left=�$��436,320,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -*   $ m3_12��$
��Left=�$��476,320,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -+   $
 m3_8��$
��Left=�$��518,290,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -,   $
 m3_9��$
��Left=�$��558,290,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� --   $ m3_13��$
��Left=�$��518,320,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -.   $ m3_14��$
��Left=�$��558,320,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -/   $ m3_15��$
��Left=�$��398,355,0,0q�$
 Wrap=�$	��Top=�$��30��$
 True���� -0   $ m3_16��$
��Left=�$��436,355,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -1   $ m3_17��$
��Left=�$��476,355,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -2   $ m3_20��$
��Left=�$��398,385,0,0q�$
 Wrap=�$	��Top=�$��30��$
 True���� -3   $ m3_21��$
��Left=�$��436,385,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -4   $ m3_22��$
��Left=�$��476,385,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -5   $ m3_18��$
��Left=�$��518,355,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -6   $ m3_19��$
��Left=�$��558,355,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -7   $ m3_23��$
��Left=�$��518,385,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True���� -8   $ m3_24��$
��Left=�$��558,385,0,0q�$
 Wrap=�$	��Top=�$��32��$
 True��