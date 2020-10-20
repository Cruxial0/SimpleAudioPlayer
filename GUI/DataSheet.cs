using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TagLib;
using static TagLib.File;

namespace SimpleAudioPlayer.GUI
{
    public class DataSheet
    {
        private uint _sampleFrequency;

        public List<FileInfo> PopulateSongList(string dirPath)
        {
            List<FileInfo> Songs = new List<FileInfo>();

            int currId = 1;

            FileInfo currentFile;
            TimeSpan currentFileLength;

            foreach (var file in Directory.GetFiles(dirPath))
            {
                if(file.EndsWith(".mp3"))
                {
                    currentFile = new FileInfo();

                    currentFile.Id = currId;
                    currId++;

                    currentFile.fileName = Path.GetFileNameWithoutExtension(file);

                    currentFileLength = TimeSpan.FromSeconds(GetMediaDuration(file));

                    int hh = currentFileLength.Hours;
                    int mm = currentFileLength.Minutes;
                    int ss = currentFileLength.Seconds;

                    currentFile.fileLength = $"{hh}h {mm}m {ss}s";

                    currentFile.filePath = file;

                    Songs.Add(currentFile);
                }
            }

            return Songs;
        }

        double GetMediaDuration(string MediaFilename)
        {
            double duration = 0.0;
            using (FileStream fs = System.IO.File.OpenRead(MediaFilename))
            {
                Mp3Frame frame = Mp3Frame.LoadFromStream(fs);
                if (frame != null)
                {
                    _sampleFrequency = (uint)frame.SampleRate;
                }
                while (frame != null)
                {
                    if (frame.ChannelMode == ChannelMode.Mono)
                    {
                        MessageBox.Show("This application does not support length calculation for MonoChannel files.");
                        return duration;
                    }
                    else
                    {
                        duration += (double)frame.SampleCount / (double)frame.SampleRate;
                    }
                    frame = Mp3Frame.LoadFromStream(fs);
                }
            }
            return duration;
        }
    }
}
