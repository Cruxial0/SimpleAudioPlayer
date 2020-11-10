using SimpleAudioPlayer.FileManager.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.Playlist
{
    public class PlaylistHelper
    {
        public KeyValuePair<PlaylistItem, string> GetBasePair(KeyValuePair<int, KeyValuePair<PlaylistItem, string>> songDetails)
        {
            var basePair = songDetails.Value;

            return basePair;
        }

        public PlaylistItem GetFileInfo(KeyValuePair<int, KeyValuePair<PlaylistItem, string>> songDetails)
        {
            var temp = songDetails.Value;

            PlaylistItem fileInfo = temp.Key;

            return fileInfo;
        }
    }
}
