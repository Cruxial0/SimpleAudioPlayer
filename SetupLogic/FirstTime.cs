using SimpleAudioPlayer.FileManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.SetupLogic
{
    public class FirstTime
    {
        public FirstTimeSetup FTS = new FirstTimeSetup();
        public ConfigManager CM = new ConfigManager();

        public void DisplayFTSWindow()
        {
            CM.InitializeDirectory();

            if (CM.ReadDirectoryConfig() == null)
            {
                FTS.Show();
                FTS.Topmost = true;
            }
        }
    }
}
