using Microsoft.Win32;
using NAudio.Gui;
using NAudio.Wave;
using SimpleAudioPlayer.Audio;
using SimpleAudioPlayer.GUI;
using SimpleAudioPlayer.OsuDirectory;
using SimpleAudioPlayer.Playlist;
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
using Windows.Media.Playlists;

namespace SimpleAudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Dir = Environment.CurrentDirectory;

        public static Dictionary<FileInfo, string> CurrentPlaylist = new Dictionary<FileInfo, string>();

        public static List<PlaylistItem> placeholder;

        private float volumePercentage;

        private readonly AudioStream AS = new AudioStream();
        private readonly DynamicGUI DGUI = new DynamicGUI();
        private readonly DataSheet DS = new DataSheet();
        private readonly FirstTime FTS = new FirstTime();

        private PlaylistItem selectedFile;

        private PlaybackState playbackState;

        public MainWindow()
        {
            InitializeComponent();

            FTS.DisplayFTSWindow();

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
            OsuFolder OF = new OsuFolder();

            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = OF.FindOsuFolder(),
                Filter = "osu! Database File| osu!.db"
            };

            if(ofd.ShowDialog() == true)
            {
                SongList.ItemsSource = DS.PopulateFromOsuDb(ofd.FileName);
                placeholder = DS.PopulateFromOsuDb(ofd.FileName);
            }
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
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                SelectedPath = Dir,
            };

            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                SongList.ItemsSource = DS.PopulateSongList(fbd.SelectedPath);
                placeholder = DS.PopulateSongList(fbd.SelectedPath);
            }
        }

        private void SongList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "filePath")
            {
                e.Cancel = true;
            }
        }

        private void SongList_SelectedCellsChanged(object sender, EventArgs e)
        {
            if (selectedFile == SongList.CurrentCell.Item as PlaylistItem)
            {
                NowPlayingTxt.Text = "null";
            }
            if (SongList.CurrentCell.Item == null) return;

            playbackState = AS.GetPlaybackState(playbackState);

            if (playbackState == PlaybackState.Playing || playbackState == PlaybackState.Paused)
            {
                selectedFile = SongList.CurrentCell.Item as PlaylistItem;

                AS.StopSong();
                Task.Delay(100).ContinueWith(_ =>
                {
                    AS.PlaySong(selectedFile, "file");
                });

                DGUI.NowPlaying(selectedFile.filePath, NowPlayingTxt);
            }

            if (playbackState == PlaybackState.Stopped)
            {
                selectedFile = SongList.CurrentCell.Item as PlaylistItem;

                AS.PlaySong(selectedFile, "file");
                DGUI.NowPlaying(selectedFile.filePath, NowPlayingTxt);
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
            PlaylistTesting PT = new PlaylistTesting();

            PT.Show();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            BrowserTesting BT = new BrowserTesting();

            BT.Show();
        }
    }

    public class FileInfo
    {
        public int Id { get; set; }
        public string fileName { get; set; }
        public string fileLength { get; set; }
        public string filePath { get; set; }
    }

    public class PlaylistItem
    {
        public int Id { get; set; }
        public string fileName { get; set; }
        public string fileLength { get; set; }
        public string filePath { get; set; }
        public string origin { get; set; }
    }
}
