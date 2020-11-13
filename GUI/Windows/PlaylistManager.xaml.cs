using Microsoft.Win32;
using Newtonsoft.Json;
using SimpleAudioPlayer.FileManager.Playlist;
using SimpleAudioPlayer.GUI;
using SimpleAudioPlayer.Playlist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SimpleAudioPlayer
{
    /// <summary>
    /// Interaction logic for PlaylistManager.xaml
    /// </summary>
    public partial class PlaylistManager : Window
    {
        public PlaylistManager()
        {
            InitializeComponent();
        }

        private PlaylistItem selectedFile;

        private void Playlist_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            selectedFile = Playlist.CurrentCell.Item as PlaylistItem;

            if (selectedFile == null) return;

            songNameTxt.Text = selectedFile.fileName;
            SongIdTxt.Text = selectedFile.Id.ToString();
            SongPathTxt.Text = selectedFile.filePath;
        }

        private void PlaylistSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            //Open new window
            //Catch all .pll files and display them
            //Return Playlist

            PlaylistConverter PC = new PlaylistConverter();

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Playlist files | *.pll",
                InitialDirectory = Path.Combine(Environment.CurrentDirectory, "jsonFiles")
            };

            if(ofd.ShowDialog() == true)
            {
                MainWindow.CurrentPlaylist = PC.GetPllFromFile(ofd.FileName);
                Playlist.ItemsSource = PC.GetPllFromFile(ofd.FileName).Songs;

                SongFileRightBtn.Text = MainWindow.CurrentPlaylist.PlaylistName;
            }
        }

        private void PlaylistCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            //ManagePlaylistJson MPJ = new ManagePlaylistJson();

            //MPJ.WritePlaylist(MainWindow.CurrentPlaylist, Path.Combine(Environment.CurrentDirectory, "jsonFiles", "playlist1.json"));

            PlaylistObject p = new PlaylistObject();

            p.PlaylistName = "playlist";
            p.sepDir = null;
            p.Songs = MainWindow.CurrentPlaylist.Songs;

            WritePlaylist(p, Path.Combine(Environment.CurrentDirectory, "jsonFiles", "playlist1.pll"));
        }

        //placeholder, REMOVE!!
        public void WritePlaylist(PlaylistObject playlist, string outputPath)
        {
            string json = JsonConvert.SerializeObject(playlist, Formatting.Indented);

            File.WriteAllText(outputPath, json);
        }

        private void ToggleMode_Click(object sender, RoutedEventArgs e)
        {
            if(ToggleMode.IsChecked.Value)
            {
                PlaylistModifyPanel.IsEnabled = true;
                SongModifyPanel.IsEnabled = true;

                ModeLabel.Foreground = new SolidColorBrush(Colors.Green);
                ModeLabel.Text = "Current Mode: Modify enabled.";
            }
            else
            {
                PlaylistModifyPanel.IsEnabled = false;
                SongModifyPanel.IsEnabled = false;

                ModeLabel.Foreground = new SolidColorBrush(Colors.Red);
                ModeLabel.Text = "Current Mode: Modify disabled.";
            }
        }
    }
}
