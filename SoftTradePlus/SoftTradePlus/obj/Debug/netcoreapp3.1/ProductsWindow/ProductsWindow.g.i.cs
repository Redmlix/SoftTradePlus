﻿#pragma checksum "..\..\..\..\ProductsWindow\ProductsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F4CC459B12803D6C31D9468749F3A976913733FB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SoftTradePlus;
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


namespace SoftTradePlus {
    
    
    /// <summary>
    /// ProductsWindow
    /// </summary>
    public partial class ProductsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SoftTradePlus.ProductsWindow window;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid productsTable;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelVertical;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox productNameTb;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox productPriceTb;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox productTypeCb;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker productDateCalendar;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBtn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteBtn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelBottom;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SoftTradePlus;component/productswindow/productswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((SoftTradePlus.ProductsWindow)(target));
            
            #line 9 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
            this.window.Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.productsTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.stackPanelVertical = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.productNameTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.productPriceTb = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
            this.productPriceTb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.productPriceValidation);
            
            #line default
            #line hidden
            return;
            case 6:
            this.productTypeCb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
            this.productTypeCb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.productTypeCb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.productDateCalendar = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.addBtn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
            this.addBtn.Click += new System.Windows.RoutedEventHandler(this.addBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.deleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
            this.deleteBtn.Click += new System.Windows.RoutedEventHandler(this.deleteBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.stackPanelBottom = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\ProductsWindow\ProductsWindow.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

