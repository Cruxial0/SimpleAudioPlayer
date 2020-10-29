using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace SimpleAudioPlayer
{
    /// <summary>
    /// Interaction logic for PlaylistTesting.xaml
    /// </summary>
    public partial class PlaylistTesting : Window
    {
        string fileName = "test.json";
        string jsonPath;

        private ManagePlaylistJson MPJ;

        public PlaylistTesting()
        {
            InitializeComponent();
            jsonPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"jsonFiles", fileName);
        }

        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            MPJ = new ManagePlaylistJson();

            MPJ.WritePlaylist(MainWindow.placeholder, jsonPath);
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            MPJ = new ManagePlaylistJson();

            var dict = MPJ.ReadPlaylist(jsonPath);

            List<FileInfo> files = new List<FileInfo>();

            foreach(var pair in dict)
            {
                files.Add(pair.Key);
            }

            Playlist.ItemsSource = files;
        }
    }
}
