﻿#pragma checksum "..\..\..\..\GUI\Windows\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "629ADA58AF05EA08F6A458231A359ED656B65F7FA655B2274EBE306F420A56E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;
using ModernWpf.DesignTime;
using ModernWpf.Markup;
using ModernWpf.Media.Animation;
using SimpleAudioPlayer.GUI.Controls;
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SongList;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar volumeDisplay;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider volumeBar;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBarTxt;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SongSelectBtn;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SongStopBtn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SongPauseBtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectDirectoryBtn;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToggleLoopBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PlaylistTesting;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Browse;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\GUI\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NowPlayingTxt;
        
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
            System.Uri resourceLocater = new System.Uri("/SimpleAudioPlayer;component/gui/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.SongList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 43 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.SongList.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.SongList_SelectedCellsChanged);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.SongList.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.SongList_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.volumeDisplay = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 3:
            this.volumeBar = ((System.Windows.Controls.Slider)(target));
            
            #line 57 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.volumeBar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.volumeBar_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.searchBarTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.searchBarTxt.KeyUp += new System.Windows.Input.KeyEventHandler(this.searchBarTxt_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SongSelectBtn = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.SongSelectBtn.Click += new System.Windows.RoutedEventHandler(this.SongSelectBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SongStopBtn = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.SongStopBtn.Click += new System.Windows.RoutedEventHandler(this.SelectDirectoryBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SongPauseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.SongPauseBtn.Click += new System.Windows.RoutedEventHandler(this.SongPauseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SelectDirectoryBtn = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.SelectDirectoryBtn.Click += new System.Windows.RoutedEventHandler(this.SongStopBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ToggleLoopBtn = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.ToggleLoopBtn.Click += new System.Windows.RoutedEventHandler(this.ToggleLoopBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PlaylistTesting = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.PlaylistTesting.Click += new System.Windows.RoutedEventHandler(this.PlaylistTesting_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Browse = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\..\GUI\Windows\MainWindow.xaml"
            this.Browse.Click += new System.Windows.RoutedEventHandler(this.Browse_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.NowPlayingTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

