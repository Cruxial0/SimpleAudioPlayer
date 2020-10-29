using Microsoft.Win32;
using NAudio.Gui;
using NAudio.Wave;
using SimpleAudioPlayer.Audio;
using SimpleAudioPlayer.GUI;
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

namespace SimpleAudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Dir = Environment.CurrentDirectory;

        private float volumePercentage;

        private readonly AudioStream AS = new AudioStream();
        private readonly DynamicGUI DGUI = new DynamicGUI();
        private readonly DataSheet DS = new DataSheet();

        private FileInfo selectedFile;

        private PlaybackState playbackState;

        public MainWindow()
        {
            InitializeComponent();

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
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = Dir,
                Filter = ".mp3 files | *.mp3"
            };

            if (ofd.ShowDialog() == true)
            {
                AS.PlaySong(ofd.FileName);
                DGUI.NowPlaying(ofd.FileName, NowPlayingTxt);
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
            if (selectedFile == SongList.CurrentCell.Item as FileInfo)
            {
                NowPlayingTxt.Text = "null";
            }
            if (SongList.CurrentCell.Item == null) return;

            playbackState = AS.GetPlaybackState(playbackState);

            if (playbackState == PlaybackState.Playing || playbackState == PlaybackState.Paused)
            {
                selectedFile = SongList.CurrentCell.Item as FileInfo;

                AS.StopSong();
                Task.Delay(100).ContinueWith(_ =>
                {
                    AS.PlaySong(selectedFile.filePath);
                });

                DGUI.NowPlaying(selectedFile.filePath, NowPlayingTxt);
            }

            if (playbackState == PlaybackState.Stopped)
            {
                selectedFile = SongList.CurrentCell.Item as FileInfo;

                AS.PlaySong(selectedFile.filePath);
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
    }

    public class FileInfo
    {
        public int Id { get; set; }
        public string fileName { get; set; }
        public string fileLength { get; set; }
        public string filePath { get; set; }
    }
}
