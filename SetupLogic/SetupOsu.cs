using Newtonsoft.Json;
using SimpleAudioPlayer.FileManager;
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

        public void WriteOsuDB(string osuDBFile)
        {
            CheckIfDirectoryExists();

            var osuSongList = DS.PopulateFromOsuDb(osuDBFile);

            string json = JsonConvert.SerializeObject(osuSongList, Formatting.Indented);

            File.WriteAllText(Path.Combine(osuWritePath, @"osuSongList.json"), json);
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
