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
        

        public void NowPlaying(string fileName, TextBlock nowPlaying)
        {
            nowPlaying.Text = $"Now Playing: {fileName}";
        }
    }
}
