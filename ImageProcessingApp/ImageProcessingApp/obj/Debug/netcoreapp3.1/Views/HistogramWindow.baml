   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ImageProcessingApp.ViewsImageProcessingApp.Views  5   	   .    (ImageProcessingApp.Views.HistogramWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ImageProcessingApp.Views     5   	     � Title$  HistogramWindow��5   	   $
��1000��6!   $	��850��6.   .��5	      � -   5         �Name$
 Grid��5	      .+�5
   
   o� $	��Top=�6   $��20��6$   $	��Top=�60   .@�5      m� $��
_Histogram��6   .@�5      m� -   5        $��_Save As...��5      60   �� 5      m� 5      -   5        $��_Close��5      6+   5      m� 5      -   5        $��zoomCtrl��5      $��_Zoom��6'   .@�5      m� -   5        $��_100%��5       m� 	IsChecked$
 True��6@   m� 5      -   5        $��_150%��5      6*   m� 5      -   5        $��_200%��5      6*   m� 5      -   5        $��_300%��5      6*   m� 5      -	   5        $��_400%��5      6*   5      m� 5      $��_Operations��6   .@�5      m� -
   5        $��_Stretching��5      60   m� 5      -   5        $��
_Alignment��5      6/   m� 5      -   5        $��_Equalization��5      62   5      5      �� 5   
   -   5         ��Name$ colorPicker��5      $��Center=�6(   $��-200,30,0,0q�6E   $	��Top=�6Z   $	��120��6r   6~   �� 5   
   -   5         ��Name$ histInfoLabel��5      $	��---��6'   $��Center=�65   $��
200,30,0,0q�6R   $	��Top=�6f   �� 5   
   -   5         ��Name$ HistPlot��5      $	��768��6"   $	��700��6.   $��	0,60,0,10q�6;   6P   �� 5    
   -   5        $ LabelminColor��5       $	��xxx��6'   $
��Left=�65   $��100,780,0,0q�6P   $	��Top=�6e   �� 5!   
   -   5        $ LabelmaxColor��5!      $	��xxx��6'   $
��Left=�65   $��860,780,0,0q�6P   $	��Top=�6e   �� 5"   
   -   5        $ LabelmaxValue��5"      $��xxxx -��6'   $
��Left=�68   $��
40,110,0,0q�6S   $	��Top=�6g   5#      5$      