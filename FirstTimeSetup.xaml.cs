using SimpleAudioPlayer.FileManager;
using SimpleAudioPlayer.OsuDirectory;
using SimpleAudioPlayer.SetupLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleAudioPlayer
{
    /// <summary>
    /// Interaction logic for FirstTimeSetup.xaml
    /// </summary>
    public partial class FirstTimeSetup : Window
    {
        public FirstTimeSetup()
        {
            InitializeComponent();
        }

        private string osuPath;
        private string localPath;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OsuFolder OF = new OsuFolder();
            SetupOsu SO = new SetupOsu();
            ConfigManager CF = new ConfigManager();

            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = OF.FindOsuFolder(),
                Filter = "osu! Database File| osu!.db"
            };

            if (ofd.ShowDialog() == true)
            {
                SO.WriteOsuDB(ofd.FileName);
                osuPath = ofd.FileName;
            }

            osuCheck.Visibility = Visibility.Visible;
            osuDirectoryBtn.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            };

            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                localPath = fbd.SelectedPath;
            }

            localCheck.Visibility = Visibility.Visible;
            localDirectoryBtn.IsEnabled = false;
        }

        private void setupFinishBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfigManager CM = new ConfigManager();

            CM.WriteDirectoryConfig(osuPath, localPath);

            this.Close();
        }
    }
}
