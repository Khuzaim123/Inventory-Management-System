﻿#pragma checksum "..\..\..\Customer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "139873138C468D08F0EC469112CAF2064C30BED7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace InventoryApp {
    
    
    /// <summary>
    /// CustomerManagement
    /// </summary>
    public partial class CustomerManagement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateCustomerButton;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteCustomerButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCustomerButton;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CustomerListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Inventory managment;component/customer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Customer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CustomerNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.UpdateCustomerButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Customer.xaml"
            this.UpdateCustomerButton.Click += new System.Windows.RoutedEventHandler(this.UpdateCustomerButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteCustomerButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Customer.xaml"
            this.DeleteCustomerButton.Click += new System.Windows.RoutedEventHandler(this.DeleteCustomerButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddCustomerButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Customer.xaml"
            this.AddCustomerButton.Click += new System.Windows.RoutedEventHandler(this.AddCustomerButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CustomerListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
