using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.FileManager
{
    public class ConfigManager
    {
        public static readonly string dirConfigPath = Path.Combine(Environment.CurrentDirectory, @"Config\");

        public void WriteDirectoryConfig(string osuPath, string localPath)
        {
            CheckIfDirectoryExists();

            DirectoryConfig configFile = new DirectoryConfig();

            configFile.osuDirectory = osuPath;
            configFile.localDirectory = localPath;

            string json = JsonConvert.SerializeObject(configFile, Formatting.Indented);

            File.WriteAllText(dirConfigPath + "DirectoryConfig.json", json);
        }

        public DirectoryConfig ReadDirectoryConfig()
        {
            if(!File.Exists(dirConfigPath + "DirectoryConfig.json"))
            {
                return null;
            }

            string json = File.ReadAllText(dirConfigPath + "DirectoryConfig.json");

            DirectoryConfig configFile = JsonConvert.DeserializeObject<DirectoryConfig>(json);

            return configFile;
        }

        public void InitializeDirectory()
        {
            CheckIfDirectoryExists();
        }

        private void CheckIfDirectoryExists()
        {
            Directory.GetCurrentDirectory();

            if(!Directory.Exists(dirConfigPath))
            {
                Directory.CreateDirectory(dirConfigPath);
            }
        }
    }

    public class DirectoryConfig
    {
        public string osuDirectory { get; set; }
        public string localDirectory { get; set; }
    }
}
