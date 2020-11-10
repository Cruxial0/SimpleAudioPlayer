using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SimpleAudioPlayer.Playlist
{
    public class ManagePlaylistJson
    {
        public void WritePlaylist(List<PlaylistItem> songList, string outputPath)
        {
            Dictionary<PlaylistItem, string> SongDetails = new Dictionary<PlaylistItem, string>();

            Dictionary<int, KeyValuePair<PlaylistItem, string>> dictToJson = new Dictionary<int, KeyValuePair<PlaylistItem, string>>();

            foreach (var file in songList)
            {
                SongDetails.Add(file, ".mp3");
            }

            int counter = 1;

            foreach (var pair in SongDetails)
            {
                dictToJson.Add(counter, pair);
                counter++;
            }

            string json = JsonConvert.SerializeObject(dictToJson, Formatting.Indented);

            File.WriteAllText(outputPath, json);
        }

        public Dictionary<FileInfo, string> ReadPlaylist(string inputPath)
        {
            string json = File.ReadAllText(inputPath);

            Dictionary<int, KeyValuePair<FileInfo, string>> songDetails = JsonConvert.DeserializeObject<Dictionary<int, KeyValuePair<FileInfo, string>>>(json);

            Dictionary<FileInfo, string> keyValuePairs = new Dictionary<FileInfo, string>();

            foreach (var pair in songDetails)
            {
                var value = pair.Value;

                keyValuePairs.Add(value.Key, value.Value);
            }

            return keyValuePairs;
        }
    }
}
