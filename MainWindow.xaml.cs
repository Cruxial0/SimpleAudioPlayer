using Microsoft.Win32;
using NAudio.Gui;
using NAudio.Wave;
using SimpleAudioPlayer.Audio;
using SimpleAudioPlayer.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private AudioStream AS = new AudioStream();
        private DynamicGUI DGUI = new DynamicGUI();

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
            OpenFileDialog ofd = new OpenFileDialog
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
    }
}
