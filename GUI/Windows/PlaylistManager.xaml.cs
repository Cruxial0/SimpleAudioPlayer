using Microsoft.Win32;
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

        private void Playlist_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void PlaylistSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            DataSheet DS = new DataSheet();

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Playlist files | *.pll",
                InitialDirectory = Path.Combine(Environment.CurrentDirectory, "jsonFiles")
            };

            if(ofd.ShowDialog() == true)
            {
                MainWindow.CurrentPlaylist = DS.PopulateFromPlaylist(ofd.FileName);
                Playlist.ItemsSource = DS.PopulateFromPlaylist(ofd.FileName);
            }
        }

        private void PlaylistCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            ManagePlaylistJson MPJ = new ManagePlaylistJson();

            MPJ.WritePlaylist(MainWindow.CurrentPlaylist, Path.Combine(Environment.CurrentDirectory, "jsonFiles", "playlist1.json"));
        }
    }
}
