﻿#pragma checksum "..\..\..\windows\AddIngredient.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AEF9753DA5E8C84BF5802576F0F8DC9E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using RCookBookDB;
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


namespace RCookBookDB {
    
    
    /// <summary>
    /// AddIngredient
    /// </summary>
    public partial class AddIngredient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\windows\AddIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Name;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\windows\AddIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Search;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\windows\AddIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lv_Category;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\windows\AddIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbox_Meat;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\windows\AddIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AddIng;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\windows\AddIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AddCategory;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\windows\AddIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Close;
        
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
            System.Uri resourceLocater = new System.Uri("/RevCookBook;component/windows/addingredient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\windows\AddIngredient.xaml"
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
            this.tb_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tb_Search = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\windows\AddIngredient.xaml"
            this.tb_Search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tb_Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lv_Category = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.cbox_Meat = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.btn_AddIng = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\windows\AddIngredient.xaml"
            this.btn_AddIng.Click += new System.Windows.RoutedEventHandler(this.btn_AddIng_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_AddCategory = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\windows\AddIngredient.xaml"
            this.btn_AddCategory.Click += new System.Windows.RoutedEventHandler(this.btn_AddCategory_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Close = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\windows\AddIngredient.xaml"
            this.btn_Close.Click += new System.Windows.RoutedEventHandler(this.btn_Close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

