﻿#pragma checksum "..\..\..\..\Windows\TableLookupByColumnName.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "03F945E7C18BD72992B76C43E13CDE40"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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


namespace BillingToolBox.Windows {
    
    
    /// <summary>
    /// TableLookupByColumnName
    /// </summary>
    public partial class TableLookupByColumnName : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_Database;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_SearchCriteria;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Find;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid_Results;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_Value;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_CreateSelect;
        
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
            System.Uri resourceLocater = new System.Uri("/BillingToolBox;component/windows/tablelookupbycolumnname.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
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
            this.comboBox_Database = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.textBox_SearchCriteria = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.button_Find = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
            this.button_Find.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGrid_Results = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.textBox_Value = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
            this.textBox_Value.GotFocus += new System.Windows.RoutedEventHandler(this.textBox_Value_GotFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
            this.textBox_Value.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.textBox_Value_GotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
            this.textBox_Value.GotMouseCapture += new System.Windows.Input.MouseEventHandler(this.textBox_Value_GotMouseCapture);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button_CreateSelect = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Windows\TableLookupByColumnName.xaml"
            this.button_CreateSelect.Click += new System.Windows.RoutedEventHandler(this.button_CreateSelect_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

