﻿#pragma checksum "..\..\..\..\Views\ThresholdingWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0C04CE584E2131FE7B175BF67BF26D8652C9F61A"
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
    /// ThresholdingWindow
    /// </summary>
    public partial class ThresholdingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\ThresholdingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CB_2;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\ThresholdingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyBtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\ThresholdingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider p1_slider;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Views\ThresholdingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox p1_TB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\ThresholdingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label p1_label;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\ThresholdingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image preview_image;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\ThresholdingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel_Btn;
        
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
            System.Uri resourceLocater = new System.Uri("/ImageProcessingApp;component/views/thresholdingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ThresholdingWindow.xaml"
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
            
            #line 8 "..\..\..\..\Views\ThresholdingWindow.xaml"
            ((ImageProcessingApp.Views.ThresholdingWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CB_2 = ((System.Windows.Controls.CheckBox)(target));
            
            #line 10 "..\..\..\..\Views\ThresholdingWindow.xaml"
            this.CB_2.Checked += new System.Windows.RoutedEventHandler(this.CB_2_Checked);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\..\Views\ThresholdingWindow.xaml"
            this.CB_2.Unchecked += new System.Windows.RoutedEventHandler(this.CB_2_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ApplyBtn = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\Views\ThresholdingWindow.xaml"
            this.ApplyBtn.Click += new System.Windows.RoutedEventHandler(this.ApplyBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.p1_slider = ((System.Windows.Controls.Slider)(target));
            
            #line 12 "..\..\..\..\Views\ThresholdingWindow.xaml"
            this.p1_slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.p1_slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.p1_TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\Views\ThresholdingWindow.xaml"
            this.p1_TB.LostFocus += new System.Windows.RoutedEventHandler(this.p1_TB_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.p1_label = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.preview_image = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.Cancel_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Views\ThresholdingWindow.xaml"
            this.Cancel_Btn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

