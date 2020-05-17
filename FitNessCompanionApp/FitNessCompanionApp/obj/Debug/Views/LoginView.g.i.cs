﻿#pragma checksum "..\..\..\Views\LoginView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "145A3F60FC9A440A712C3D80B9DADBF7D9B98290"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FitNessCompanionApp.Views;
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


namespace FitNessCompanionApp.Views {
    
    
    /// <summary>
    /// LoginView
    /// </summary>
    public partial class LoginView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 140 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name_Login;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password_Login;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name_SignUp;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse UsernameBubble;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email_SignUp;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse EmailBubble;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password_SignUp;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordConfirm_SignUp;
        
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
            System.Uri resourceLocater = new System.Uri("/FitNessCompanionApp;component/views/loginview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\LoginView.xaml"
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
            
            #line 104 "..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MenuBar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 117 "..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 118 "..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Maximize_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 119 "..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Minimize_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Name_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Password_Login = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 142 "..\..\..\Views\LoginView.xaml"
            this.Password_Login.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewPasswordInput);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 144 "..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Name_SignUp = ((System.Windows.Controls.TextBox)(target));
            
            #line 155 "..\..\..\Views\LoginView.xaml"
            this.Name_SignUp.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PreviewUsernameInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UsernameBubble = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 10:
            this.Email_SignUp = ((System.Windows.Controls.TextBox)(target));
            
            #line 160 "..\..\..\Views\LoginView.xaml"
            this.Email_SignUp.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PreviewEmailInput);
            
            #line default
            #line hidden
            return;
            case 11:
            this.EmailBubble = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 12:
            this.Password_SignUp = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 164 "..\..\..\Views\LoginView.xaml"
            this.Password_SignUp.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewPasswordInput);
            
            #line default
            #line hidden
            return;
            case 13:
            this.PasswordConfirm_SignUp = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 166 "..\..\..\Views\LoginView.xaml"
            this.PasswordConfirm_SignUp.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewPasswordInput);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 168 "..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignUp_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

