﻿using Newtonsoft.Json;
using SimpleAudioPlayer.FileManager.Playlist;
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
        public void WritePlaylist(PlaylistObject playlist, string outputPath)
        {
            string json = JsonConvert.SerializeObject(playlist, Formatting.Indented);

            File.WriteAllText(outputPath, json);
        }

        //public Dictionary<FileInfo, string> ReadPlaylist(string inputPath)
        //{
        //    string json = File.ReadAllText(inputPath);

        //    Dictionary<int, KeyValuePair<FileInfo, string>> songDetails = JsonConvert.DeserializeObject<Dictionary<int, KeyValuePair<FileInfo, string>>>(json);

        //    Dictionary<FileInfo, string> keyValuePairs = new Dictionary<FileInfo, string>();

        //    foreach (var pair in songDetails)
        //    {
        //        var value = pair.Value;

        //        keyValuePairs.Add(value.Key, value.Value);
        //    }

        //    return keyValuePairs;
        //}
    }
}
