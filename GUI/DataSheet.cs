using NAudio.Wave;
using Newtonsoft.Json;
using osu_database_reader.BinaryFiles;
using SimpleAudioPlayer.Playlist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TagLib;

namespace SimpleAudioPlayer.GUI
{
    public class DataSheet
    {
        private uint _sampleFrequency;

        public List<PlaylistItem> ApplyPlaylist(Dictionary<FileInfo, string> currentPlaylist)
        {
            List<PlaylistItem> items = new List<PlaylistItem>();

            foreach(var item in currentPlaylist)
            {
                PlaylistItem currItem = new PlaylistItem();
                FileInfo temp = item.Key;

                currItem.Id = temp.Id;
                currItem.fileName = temp.fileName;
                currItem.filePath = temp.filePath;
                currItem.fileLength = temp.fileLength;
                currItem.origin = item.Value;

                items.Add(currItem);
            }

            return items;
        }

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

                    int hh = currentFileLength.Hours;
                    int mm = currentFileLength.Minutes;
                    int ss = currentFileLength.Seconds;

                    currentFile.fileLength = $"{hh}h {mm}m {ss}s";

                    currentFile.filePath = file;
                    currentFile.origin = "file";

                    Songs.Add(currentFile);
                }
            }

            return Songs;
        }

        public List<PlaylistItem> PopulateFromOsuDb(string filePath)
        {
            OsuDb db = OsuDb.Read(filePath);

            List<PlaylistItem> Songs = new List<PlaylistItem>();

            int currId = 1;

            PlaylistItem currentFile;
            TimeSpan currentFileLength;
            TagLib.File tfile;

            string currentFileName = "";

            foreach (var item in db.Beatmaps)
            {
                if(item.FolderName != currentFileName)
                {
                    currentFile = new PlaylistItem();

                    var file = $@"{filePath.Replace("osu!.db", string.Empty)}Songs\{item.FolderName}\{item.AudioFileName}";

                    try
                    {
                        tfile = TagLib.File.Create(file);
                        currentFileLength = tfile.Properties.Duration;
                        tfile.Dispose();

                        int hh = currentFileLength.Hours;
                        int mm = currentFileLength.Minutes;
                        int ss = currentFileLength.Seconds;

                        currentFile.fileLength = $"{hh}h {mm}m {ss}s";
                    }
                    catch(Exception e)
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

            return Songs;
        }

        public List<PlaylistItem> PopulateFromPlaylist(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);

            List<PlaylistItem> playlist = JsonConvert.DeserializeObject<List<PlaylistItem>>(json);

            return playlist;
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
