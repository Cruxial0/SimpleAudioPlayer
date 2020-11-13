using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.FileManager.Playlist
{
    public class PlaylistConverter
    {
        public PlaylistObject GetPllFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<PlaylistObject>(json);
        }
    }
}
