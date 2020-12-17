using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
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

namespace SimpleAudioPlayer.GUI.Controls
{
    /// <summary>
    /// Interaction logic for SongListItem.xaml
    /// </summary>
    public partial class SongListItem : UserControl
    {
        #region Properties
        private string _songTitle;
        private string _songArtist;
        private string _songLength;
        private string _fileOrigin;
        private string _filePath;
        private ImageSource _background;

        ImageBrush SongImageBackground = new ImageBrush();

        [Category("Custom Props")]
        public string SongTitle
        {
            get { return _songTitle; }
            set { _songTitle = value; lblSongName.Content = value; }
        }

        [Category("Custom Props")]
        public string SongArtist
        {
            get { return _songArtist; }
            set { _songArtist = value; lblArtist.Content = value; }
        }

        [Category("Custom Props")]
        public string SongLength
        {
            get { return _songLength; }
            set { _songLength = value; lblSongLength.Content = value; }
        }

        [Category("Custom Props")]
        public string FileOrigin
        {
            get { return _fileOrigin; }
            set { _fileOrigin = value; lblFileOrigin.Content = value; }
        }



        [Category("Custom Props")]
        public ImageSource background
        {
            get { return _background; }
            set { _background = value; this.Background = SongImageBackground = new ImageBrush(background); }
        }
        #endregion

        public SongListItem()
        {
            InitializeComponent();
        }

    }
}
