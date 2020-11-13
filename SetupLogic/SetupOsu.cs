using Newtonsoft.Json;
using SimpleAudioPlayer.FileManager;
using SimpleAudioPlayer.FileManager.Playlist;
using SimpleAudioPlayer.GUI;
using SimpleAudioPlayer.OsuDirectory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.SetupLogic
{
    public class SetupOsu
    {
        internal readonly string osuWritePath = Path.Combine(ConfigManager.dirConfigPath, @"osu!\");

        private DataSheet DS = new DataSheet();

        public async void WriteOsuDB(string osuDBFile)
        {
            CheckIfDirectoryExists();

            PlaylistObject p = new PlaylistObject();

            p.PlaylistName = "defaultOsuPlaylist";
            p.sepDir = null;
            p.Songs = await DS.PopulateFromOsuDb(osuDBFile);


            string json = JsonConvert.SerializeObject(p, Formatting.Indented);
            
            File.WriteAllText(Path.Combine(osuWritePath, @"defaultOsuPlaylist.json"), json);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            //p = null;
        }

        private void CheckIfDirectoryExists()
        {
            Directory.GetCurrentDirectory();

            if (!Directory.Exists(osuWritePath))
            {
                Directory.CreateDirectory(osuWritePath);
            }
        }
    }
}
