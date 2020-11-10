using SimpleAudioPlayer.FileManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer
{
    public class Config
    {
        public string OsuPath { get; set; }
        public string OsuPlaylist { get; set; }
        public string LocalPath { get; set; }

        public void InitializeConfig()
        {
            ConfigManager CM = new ConfigManager();

            OsuPath = CM.ReadDirectoryConfig().osuDirectory;
            LocalPath = CM.ReadDirectoryConfig().localDirectory;
            OsuPlaylist = Path.Combine(ConfigManager.dirConfigPath, @"osu!\osuSongList.json");
        }
    }
}
