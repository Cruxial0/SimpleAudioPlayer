using DiscordRPC;
using DiscordRPC.Logging;
using Microsoft.Win32;
using NAudio.Gui;
using NAudio.Wave;
using SimpleAudioPlayer.Audio;
using SimpleAudioPlayer.Extensions;
using SimpleAudioPlayer.FileManager;
using SimpleAudioPlayer.FileManager.Playlist;
using SimpleAudioPlayer.GUI;
using SimpleAudioPlayer.OsuDirectory;
using SimpleAudioPlayer.Playlist;
using SimpleAudioPlayer.RPCHelper;
using SimpleAudioPlayer.SetupLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Windows.Media.Playlists;

namespace SimpleAudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Dir = Environment.CurrentDirectory;

        private readonly Config Config = new Config();

        public static PlaylistObject CurrentPlaylist;

        private float volumePercentage;

        public delegate void onChangeSongChangedEvent();
        public static event onChangeSongChangedEvent ChangeSongChanged;
        public static bool ChangeSong;
        public bool changeSong
        {
            get
            {
                return ChangeSong;
            }
            set
            {
                //changeSong = value;
                ChangeSongChanged?.Invoke();
            }
        }

        private readonly AudioStream AS = new AudioStream();
        private readonly DynamicGUI DGUI = new DynamicGUI();
        private readonly DataSheet DS = new DataSheet();
        private readonly FirstTime FTS = new FirstTime();
        private readonly PlaylistConverter PC = new PlaylistConverter();
        private readonly OriginConvert OC = new OriginConvert();
        private readonly RPCHelper.RPCHelper RPC = new RPCHelper.RPCHelper();

        private PlaylistItem selectedFile;

        private PlaybackState playbackState;

        public static DiscordRpcClient client;
        public RichPresence discordPresence;

        public MainWindow()
        {
            InitializeComponent();

            RPC.Initialize();
            RPC.StartupRPC();

            FTS.DisplayFTSWindow();

            this.Closed += MainWindow_Closed;
            ChangeSongChanged += MainWindow_ChangeSongChanged;

            volumePercentage = (float)volumeBar.Value / 100;
        }

        public void volumeBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            volumeDisplay.Value = volumeBar.Value;

            volumePercentage = (float)volumeBar.Value / 100;

            AS.ChangeVolume(volumePercentage);
        }

        private void SongSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            Config.InitializeConfig();

            SongList.ItemsSource = PC.GetPllFromFile(Config.OsuPlaylist).Songs;
            CurrentPlaylist = PC.GetPllFromFile(Config.OsuPlaylist);

            searchBarTxt.IsEnabled = true;
        }

        private void SongStopBtn_Click(object sender, RoutedEventArgs e)
        {
            AS.StopSong();
        }

        private void SongPauseBtn_Click(object sender, RoutedEventArgs e)
        {
            AS.TogglePauseSong();
        }

        private void SelectDirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Config.InitializeConfig();

            SetupOsu SO = new SetupOsu();

            SO.WriteOsuDB(Config.OsuPath);
        }

        private void SongList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "filePath")
            {
                e.Cancel = true;
            }
            if(propertyDescriptor.DisplayName == "fileName")
            {
                e.Column.Header = "Song Name";
            }
            if (propertyDescriptor.DisplayName == "fileLength")
            {
                e.Column.Header = "Length";
            }
            if (propertyDescriptor.DisplayName == "origin")
            {
                e.Column.Header = "Origin";
            }
            if (propertyDescriptor.DisplayName == "artist")
            {
                e.Column.Header = "Artist";
            }
        }

        private int currentRow = 0;
        private void SongList_SelectedCellsChanged(object sender, EventArgs e)
        {
            if (SongList.SelectedCells.Count > 1) return;

            if (selectedFile == SongList.CurrentCell.Item as PlaylistItem)
            {
                return;
            }
            if (SongList.CurrentCell.Item == null) return;

            playbackState = AS.GetPlaybackState(playbackState);

            if (playbackState == PlaybackState.Playing || playbackState == PlaybackState.Paused)
            {
                selectedFile = SongList.CurrentCell.Item as PlaylistItem;

                if (selectedFile == null) return;

                AS.StopSong();
                Task.Delay(100).ContinueWith(_ =>
                {
                    AS.PlaySong(selectedFile, "file");
                });

                DGUI.NowPlaying($"{selectedFile.artist} - {selectedFile.fileName}", NowPlayingTxt);

                currentRow = SongList.SelectedIndex;

                #region DiscordRPC
                RPC.EditDetails($"Playing: {selectedFile.artist} - {selectedFile.fileName}", "In Song List");
                RPC.EditImage("Listening.", OC.OriginToImageText(selectedFile.origin));
                RPC.EditImageKeys(null, OC.OriginToImageText(selectedFile.origin));
                #endregion
            }

            if (playbackState == PlaybackState.Stopped)
            {
                selectedFile = SongList.CurrentCell.Item as PlaylistItem;

                AS.PlaySong(selectedFile, "file");
                DGUI.NowPlaying(selectedFile.filePath, NowPlayingTxt);
            }
        }

        private void MainWindow_ChangeSongChanged()
        {
            if (!changeSong) return;

            if(currentRow != -1)
            {
                if (currentRow < SongList.Items.Count)
                {
                    SongList.SelectedIndex++;
                }
                changeSong = false;
            }
        }

        private void ToggleLoopBtn_Click(object sender, RoutedEventArgs e)
        {
            AS.ToggleLoop();
        }

        public void ClearGrid(object obj)
        {
            var dg = obj as System.Windows.Controls.DataGrid;
            if (dg != null)
            {
                dg.UnselectAllCells();
            }
        }

        private void PlaylistTesting_Click(object sender, RoutedEventArgs e)
        {
            PlaylistManager PM = new PlaylistManager();

            PM.Show();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            BrowserTesting BT = new BrowserTesting();

            BT.Show();
        }


        private void MainWindow_Closed(object sender, EventArgs e)
        {
            client.Deinitialize();
            client.Dispose();

            System.Windows.Application.Current.Shutdown();
        }

        private void searchBarTxt_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            List<PlaylistItem> filtered = new List<PlaylistItem>();

            foreach(var song in CurrentPlaylist.Songs)
            {
                if (song.fileName.ContainsToLower(searchBarTxt.Text, StringComparison.OrdinalIgnoreCase))
                {
                    filtered.Add(song);
                }

                if (song.artist.ContainsToLower(searchBarTxt.Text, StringComparison.OrdinalIgnoreCase))
                {
                    filtered.Add(song);
                }

                if (song.Id.ToString().ContainsToLower(searchBarTxt.Text, StringComparison.OrdinalIgnoreCase))
                {
                    filtered.Add(song);
                }
            }



            SongList.ItemsSource = filtered;
        }
    }
}
