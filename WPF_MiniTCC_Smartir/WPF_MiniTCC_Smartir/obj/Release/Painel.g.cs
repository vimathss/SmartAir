﻿#pragma checksum "..\..\Painel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58442D9C5A6FD5AE8213CFEC845A334185BCA2799AF13586A989B7565BE298E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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
using WPF_MiniTCC_Smartir;


namespace WPF_MiniTCC_Smartir {
    
    
    /// <summary>
    /// Painel
    /// </summary>
    public partial class Painel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome icnAddUser;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome icnAddLab;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome icnAddEsp;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LaboratoriosList;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdMenuControl;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitulo;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblIdEsp;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblStatusEsp;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTempLab;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\Painel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome icnBDAcess;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_MiniTCC_Smartir;component/painel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Painel.xaml"
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
            this.icnAddUser = ((FontAwesome.WPF.ImageAwesome)(target));
            
            #line 16 "..\..\Painel.xaml"
            this.icnAddUser.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icnAddUser_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.icnAddLab = ((FontAwesome.WPF.ImageAwesome)(target));
            
            #line 17 "..\..\Painel.xaml"
            this.icnAddLab.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icnAddLab_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.icnAddEsp = ((FontAwesome.WPF.ImageAwesome)(target));
            
            #line 18 "..\..\Painel.xaml"
            this.icnAddEsp.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icnAddEsp_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LaboratoriosList = ((System.Windows.Controls.ListBox)(target));
            
            #line 23 "..\..\Painel.xaml"
            this.LaboratoriosList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LaboratoriosList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grdMenuControl = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.lblTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblIdEsp = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblStatusEsp = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblTempLab = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.icnBDAcess = ((FontAwesome.WPF.ImageAwesome)(target));
            
            #line 100 "..\..\Painel.xaml"
            this.icnBDAcess.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icnBDAcess_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

