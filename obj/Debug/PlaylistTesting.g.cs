﻿#pragma checksum "..\..\PlaylistTesting.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "589DBAC20FFD1F3CB2B0AF9503D622D25406CD84B6ADD3A2C6756991A3389538"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SimpleAudioPlayer;
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


namespace SimpleAudioPlayer {
    
    
    /// <summary>
    /// PlaylistTesting
    /// </summary>
    public partial class PlaylistTesting : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\PlaylistTesting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Playlist;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\PlaylistTesting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnWrite;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\PlaylistTesting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton BtnRead;
        
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
            System.Uri resourceLocater = new System.Uri("/SimpleAudioPlayer;component/playlisttesting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PlaylistTesting.xaml"
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
            this.Playlist = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.BtnWrite = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\PlaylistTesting.xaml"
            this.BtnWrite.Click += new System.Windows.RoutedEventHandler(this.BtnWrite_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnRead = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 61 "..\..\PlaylistTesting.xaml"
            this.BtnRead.Click += new System.Windows.RoutedEventHandler(this.BtnRead_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

