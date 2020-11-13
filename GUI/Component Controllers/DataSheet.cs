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
                TimeSpan currentFileLength;
                TagLib.File tfile;

                int currId = 1;

                string currentFileName = "";

                foreach (var item in db.Beatmaps)
                {
                    if (item.FolderName != currentFileName)
                    {
                        currentFile = new PlaylistItem();

                        var file = $@"{filePath.Replace("osu!.db", string.Empty)}Songs\{item.FolderName}\{item.AudioFileName}";

                        try
                        {
                            tfile = TagLib.File.Create(file);
                            currentFileLength = tfile.Properties.Duration;
                            tfile.Dispose();

                            currentFile.fileLength = currentFile.setFormattedTimeSpan(currentFileLength);
                        }
                        catch (Exception e)
                        {
                            currentFile = null;
                            continue;
                        }

                        currentFile.Id = currId;
                        currId++;

                        var folderName = item.FolderName;

                        Regex regex = new Regex(@"\s");
                        string[] bits = regex.Split(folderName);

                        bits[0] = "0_0_0";
                        bits = bits.Where(val => val != "0_0_0").ToArray();

                        folderName = String.Join(" ", bits);

                        currentFile.fileName = folderName;
                        currentFileName = item.FolderName;

                        currentFile.filePath = file;
                        currentFile.origin = "osu!";

                        Songs.Add(currentFile);
                    }
                }
            });

            sw.Stop();

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
                    duration += (double)frame.SampleCount / (double)frame.SampleRate;

                    frame = Mp3Frame.LoadFromStream(fs);
                }
            }
            return duration;
        }
    }
}
