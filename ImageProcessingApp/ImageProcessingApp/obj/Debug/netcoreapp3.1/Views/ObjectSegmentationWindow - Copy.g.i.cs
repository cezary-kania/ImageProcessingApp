﻿#pragma checksum "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B2ACD9D3F80BF2CD3FE9ED68B9F279B75028FF8C"
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
    /// ObjectSegmentationWindow
    /// </summary>
    public partial class ObjectSegmentationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label th1LB;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox th1TB;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label th2LB;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox th2TB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image preview_image;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label objsCounterLB;
        
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
            System.Uri resourceLocater = new System.Uri("/ImageProcessingApp;component/views/objectsegmentationwindow%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
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
            this.th1LB = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.th1TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
            this.th1TB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.th1TB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.th2LB = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.th2TB = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
            this.th2TB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.th2TB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ApplyBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
            this.ApplyBtn.Click += new System.Windows.RoutedEventHandler(this.ApplyBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Views\ObjectSegmentationWindow - Copy.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.preview_image = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.objsCounterLB = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

