﻿#pragma checksum "..\..\..\UI\FurnitureWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "56E794722CF715CA56C53931E0F8E577"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyApplication.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace MyApplication.UI {
    
    
    /// <summary>
    /// FurnitureWindow
    /// </summary>
    public partial class FurnitureWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\UI\FurnitureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UI\FurnitureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrice;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\UI\FurnitureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbQuantity;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\UI\FurnitureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFurnitureType;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\UI\FurnitureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbActionSale;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\UI\FurnitureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddEditFurniture;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyApplication;component/ui/furniturewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\FurnitureWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\UI\FurnitureWindow.xaml"
            this.tbName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\UI\FurnitureWindow.xaml"
            this.tbPrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPrice_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbQuantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\UI\FurnitureWindow.xaml"
            this.tbQuantity.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbQuantity_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbFurnitureType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbActionSale = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnAddEditFurniture = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\UI\FurnitureWindow.xaml"
            this.btnAddEditFurniture.Click += new System.Windows.RoutedEventHandler(this.btnAddEditFurniture_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

