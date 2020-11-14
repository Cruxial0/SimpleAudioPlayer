using NAudio.Wave;
using Newtonsoft.Json;
using osu_database_reader.BinaryFiles;
using SimpleAudioPlayer.FileManager.Playlist;
using SimpleAudioPlayer.Playlist;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TagLib;

namespace SimpleAudioPlayer.GUI
{
    public class DataSheet
    {
        private uint _sampleFrequency;

        public List<PlaylistItem> PopulateSongList(string dirPath)
        {
            List<PlaylistItem> Songs = new List<PlaylistItem>();

            int currId = 1;

            PlaylistItem currentFile;
            TimeSpan currentFileLength;

            foreach (var file in Directory.GetFiles(dirPath))
            {
                if(file.EndsWith(".mp3"))
                {
                    currentFile = new PlaylistItem();

                    currentFile.Id = currId;
                    currId++;

                    currentFile.fileName = Path.GetFileNameWithoutExtension(file);

                    currentFileLength = TimeSpan.FromSeconds(GetMediaDuration(file));

                    currentFile.fileLength = currentFile.setFormattedTimeSpan(currentFileLength);

                    currentFile.filePath = file;
                    currentFile.origin = "file";

                    Songs.Add(currentFile);
                }
            }

            return Songs;
        }

        public async Task<List<PlaylistItem>> PopulateFromOsuDb(string filePath)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            OsuDb db = OsuDb.Read(filePath);

            List<PlaylistItem> Songs = new List<PlaylistItem>();

            await Task.Run(() =>
            {
                PlaylistItem currentFile;

                int currId = 1;

                string currentFileName = "";

                foreach (var item in db.Beatmaps)
                {
                    if (item.FolderName != currentFileName)
                    {
                        if(item.TotalTime >= 1000)
                        {
                            currentFile = new PlaylistItem();

                            var file = $@"{filePath.Replace("osu!.db", string.Empty)}Songs\{item.FolderName}\{item.AudioFileName}";

                            currentFile.fileLength = currentFile.setFormattedTimeSpan(TimeSpan.FromMilliseconds(item.TotalTime));

                            currentFile.Id = currId;
                            currId++;

                            currentFile.fileName = $"{item.Artist} - {item.Title}";
                            currentFileName = item.FolderName;

                            currentFile.filePath = file;
                            currentFile.origin = "osu!";

                            Songs.Add(currentFile);
                        }
                    }
                }
            });

            sw.Stop();

            return Songs;
        }

        public int GetLeadingNumber(string input)
        {
            char[] chars = input.ToCharArray();
            int lastValid = -1;

            for (int i = 0; i < chars.Length; i++)
            {
                if (Char.IsDigit(chars[i]))
                {
                    lastValid = i;
                }
                else
                {
                    break;
                }
            }

            if (lastValid >= 0)
            {
                return int.Parse(new string(chars, 0, lastValid + 1));
            }
            else
            {
                return -1;
            }
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
                    duration += (double)frame.SampleCount / (double)frame.SampleRate;

                    frame = Mp3Frame.LoadFromStream(fs);
                }
            }
            return duration;
        }
    }
}
