﻿#pragma checksum "..\..\ProgramTry.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "13CBE7714AA3A78777DFCD48F7F42C891448DA040095193238EB73978161D14B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EyesPower;
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


namespace EyesPower {
    
    
    /// <summary>
    /// ProgramTry
    /// </summary>
    public partial class ProgramTry : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\ProgramTry.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal EyesPower.ProgramTry ___main;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\ProgramTry.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btdone;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ProgramTry.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listprocforward;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ProgramTry.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listprocback;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ProgramTry.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btforward;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ProgramTry.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lbback;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ProgramTry.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btadd;
        
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
            System.Uri resourceLocater = new System.Uri("/EyesPower;component/programtry.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProgramTry.xaml"
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
            this.___main = ((EyesPower.ProgramTry)(target));
            
            #line 8 "..\..\ProgramTry.xaml"
            this.___main.Closing += new System.ComponentModel.CancelEventHandler(this.___main_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btdone = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\ProgramTry.xaml"
            this.btdone.Click += new System.Windows.RoutedEventHandler(this.btdone_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listprocforward = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.listprocback = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.btforward = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ProgramTry.xaml"
            this.btforward.Click += new System.Windows.RoutedEventHandler(this.btforward_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lbback = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btadd = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\ProgramTry.xaml"
            this.btadd.Click += new System.Windows.RoutedEventHandler(this.btadd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

