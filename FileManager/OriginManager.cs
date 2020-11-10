using SimpleAudioPlayer.FileManager.Playlist;
using SimpleAudioPlayer.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.FileManager
{
    public class OriginManager
    {
        public void DetermineOrigin(KeyValuePair<int, KeyValuePair<PlaylistItem, string>> songDetails)
        {
            PlaylistHelper PH = new PlaylistHelper();

            var basePair = PH.GetBasePair(songDetails);

            PlaylistItem fileInfo = PH.GetFileInfo(songDetails);
            var id = fileInfo.Id;
            var origin = basePair.Value;

            //switch??

            //Switch on Origins
        }
    }
}
