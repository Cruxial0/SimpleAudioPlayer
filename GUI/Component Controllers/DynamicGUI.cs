using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TagLib;

namespace SimpleAudioPlayer.GUI
{
    public class DynamicGUI
    {
        

        public void NowPlaying(string filePath, TextBlock nowPlaying)
        {
            var fileName = Path.GetFileName(filePath);

            fileName.Replace(".mp3", string.Empty);

            nowPlaying.Text = $"Now Playing: {fileName}";
        }
    }

    class MusicID3Tag
    {

        public byte[] TAGID = new byte[3];      //  3
        public byte[] Title = new byte[30];     //  30
        public byte[] Artist = new byte[30];    //  30 
        public byte[] Album = new byte[30];     //  30 
        public byte[] Year = new byte[4];       //  4 
        public byte[] Comment = new byte[30];   //  30 
        public byte[] Genre = new byte[1];      //  1

    }
}
