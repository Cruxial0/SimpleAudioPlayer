using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.FileManager.Playlist
{
    public class PlaylistObject
    {
        public string PlaylistName { get; set; }
        public string sepDir { get; set; }
        public List<PlaylistItem> Songs { get; set; }
    }

    public class PlaylistItem
    {
        public int Id { get; set; }
        public string artist { get; set; }
        public string fileName { get; set; }
        public TimeSpan fileLength { get; set; }
        public string filePath { get; set; }
        public string origin { get; set; }

        public TimeSpan setFormattedTimeSpan(TimeSpan input)
        {
            input = new TimeSpan(input.Hours, input.Minutes, input.Seconds);

            return input;
        }
    }
}
