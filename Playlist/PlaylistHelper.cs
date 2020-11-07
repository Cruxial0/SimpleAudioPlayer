using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.Playlist
{
    public class PlaylistHelper
    {


        public KeyValuePair<FileInfo, string> GetBasePair(KeyValuePair<int, KeyValuePair<FileInfo, string>> songDetails)
        {
            var basePair = songDetails.Value;

            return basePair;
        }

        public FileInfo GetFileInfo(KeyValuePair<int, KeyValuePair<FileInfo, string>> songDetails)
        {
            var temp = songDetails.Value;

            FileInfo fileInfo = temp.Key;

            return fileInfo;
        }
    }
}
