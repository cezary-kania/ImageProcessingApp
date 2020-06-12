﻿#pragma checksum "..\..\..\..\..\Views\ImageWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29F96E48260789F134C73D88DD30E8CD482930D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ImageProcessingApp.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ImageProcessingApp.Views {
    
    
    /// <summary>
    /// ImageWindow
    /// </summary>
    public partial class ImageWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem NeighborhoodOpMI;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem BluringMI;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem EdetectionMI;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem LSharpeningMI;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PrewittEDetectionMI;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem CustomMaskMI;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MedianBlurMI;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MaskConvolutionMI;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Views\ImageWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageControl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ImageProcessingApp;component/views/imagewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\ImageWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((ImageProcessingApp.Views.ImageWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveAsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 14 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DuplicateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 16 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 19 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.HistogramBtnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 23 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.NegationBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 24 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ThresholdingBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 25 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.PosterizeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 26 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.LumRangeStr_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 27 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Lab5_th_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.NeighborhoodOpMI = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 13:
            this.BluringMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 30 "..\..\..\..\..\Views\ImageWindow.xaml"
            this.BluringMI.Click += new System.Windows.RoutedEventHandler(this.BluringBtn_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.EdetectionMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 31 "..\..\..\..\..\Views\ImageWindow.xaml"
            this.EdetectionMI.Click += new System.Windows.RoutedEventHandler(this.EdetectionBtn_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.LSharpeningMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 32 "..\..\..\..\..\Views\ImageWindow.xaml"
            this.LSharpeningMI.Click += new System.Windows.RoutedEventHandler(this.LSharpeningMI__Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.PrewittEDetectionMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 33 "..\..\..\..\..\Views\ImageWindow.xaml"
            this.PrewittEDetectionMI.Click += new System.Windows.RoutedEventHandler(this.PrewittEDetectionMI_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.CustomMaskMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 34 "..\..\..\..\..\Views\ImageWindow.xaml"
            this.CustomMaskMI.Click += new System.Windows.RoutedEventHandler(this.CustomMaskMI_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.MedianBlurMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 35 "..\..\..\..\..\Views\ImageWindow.xaml"
            this.MedianBlurMI.Click += new System.Windows.RoutedEventHandler(this.MedianBlurMI_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.MaskConvolutionMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 36 "..\..\..\..\..\Views\ImageWindow.xaml"
            this.MaskConvolutionMI.Click += new System.Windows.RoutedEventHandler(this.MaskConvolutionMI_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 38 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MorphologicalOP_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 39 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Skeletonization_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 40 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ObjsSeg_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 41 "..\..\..\..\..\Views\ImageWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.FVector_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            this.imageControl = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

