﻿#pragma checksum "..\..\..\..\Views\UserControl1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2B14B2508372E9E04972902BB037285E4B90F77B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ImageProcessingApp;
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


namespace ImageProcessingApp {
    
    
    /// <summary>
    /// UserControl1
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem NeighborhoodOpMI;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem BluringMI;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem EdetectionMI;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem LSharpeningMI;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem PrewittEDetectionMI;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem CustomMaskMI;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MedianBlurMI;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MaskConvolutionMI;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\UserControl1.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ImageProcessingApp;component/views/usercontrol1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\UserControl1.xaml"
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
            
            #line 12 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveAsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DuplicateBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 19 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.HistogramBtnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 23 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.NegationBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 24 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ThresholdingBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 25 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.PosterizeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 26 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.LumRangeStr_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 27 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Lab5_th_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.NeighborhoodOpMI = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 12:
            this.BluringMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 30 "..\..\..\..\Views\UserControl1.xaml"
            this.BluringMI.Click += new System.Windows.RoutedEventHandler(this.BluringBtn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.EdetectionMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 31 "..\..\..\..\Views\UserControl1.xaml"
            this.EdetectionMI.Click += new System.Windows.RoutedEventHandler(this.EdetectionBtn_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.LSharpeningMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 32 "..\..\..\..\Views\UserControl1.xaml"
            this.LSharpeningMI.Click += new System.Windows.RoutedEventHandler(this.LSharpeningMI__Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.PrewittEDetectionMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 33 "..\..\..\..\Views\UserControl1.xaml"
            this.PrewittEDetectionMI.Click += new System.Windows.RoutedEventHandler(this.PrewittEDetectionMI_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.CustomMaskMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 34 "..\..\..\..\Views\UserControl1.xaml"
            this.CustomMaskMI.Click += new System.Windows.RoutedEventHandler(this.CustomMaskMI_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.MedianBlurMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 35 "..\..\..\..\Views\UserControl1.xaml"
            this.MedianBlurMI.Click += new System.Windows.RoutedEventHandler(this.MedianBlurMI_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.MaskConvolutionMI = ((System.Windows.Controls.MenuItem)(target));
            
            #line 36 "..\..\..\..\Views\UserControl1.xaml"
            this.MaskConvolutionMI.Click += new System.Windows.RoutedEventHandler(this.MaskConvolutionMI_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 38 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MorphologicalOP_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 39 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Skeletonization_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 40 "..\..\..\..\Views\UserControl1.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ObjsSeg_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.imageControl = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
