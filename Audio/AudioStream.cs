using DiscordRPC;
using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using SimpleAudioPlayer.FileManager.Playlist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAudioPlayer.Audio
{
    class AudioStream
    {
        private IWavePlayer wavePlayer;
        private float localVolume = 1f;
        private AudioFileReader audioFile;

        private bool enableLooping = false;

        private LoopStream LS;
        private RPCHelper.RPCHelper RPC = new RPCHelper.RPCHelper();

        private PlaylistItem currentItem = null;

        private DateTime currentTimestamp = new DateTime();
        private Timestamps Timestamp = new Timestamps();

        public void PlaySong(PlaylistItem fileInfo, string Origin)
        {
            switch (Origin)
            {
                case "file":
                    PlayMusicFile(fileInfo);
                    break;

                case "web":
                    PlayYouTube(fileInfo);
                    break;

                default:
                    MessageBox.Show($"'{Origin} is not a valid file origin! Playback stopped.'", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void PlayMusicFile(PlaylistItem fileInfo)
        {
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
                audioFile = new AudioFileReader(fileInfo.filePath);

                audioFile.Volume = localVolume;

                LS = new LoopStream(audioFile, enableLooping);

                if (LS == null) return;

                if (LS.EnableLooping) wavePlayer.Init(LS);
                else
                {
                    currentTimestamp = DateTime.UtcNow.Add(fileInfo.fileLength);

                    Timestamp.Start = DateTime.Now;
                    Timestamp.End = currentTimestamp;

                    RPC.SetTimestamp(Timestamp);

                    wavePlayer.Init(audioFile);
                }

                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                wavePlayer.Play();

                currentItem = fileInfo;
            }
            else
            {
                wavePlayer.Stop();
                wavePlayer.Dispose();
                wavePlayer = null;
            }
        }

        private void PlayYouTube(PlaylistItem fileInfo)
        {
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
                var mf = new MediaFoundationReader(fileInfo.filePath);

                var memory = new MemoryStream();

                audioFile.Volume = localVolume;

                LS = new LoopStream(mf, enableLooping);

                wavePlayer.Init(LS);
                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                wavePlayer.Play();

                currentItem = fileInfo;
            }
            else
            {
                wavePlayer.Stop();
                wavePlayer.Dispose();
                wavePlayer = null;
            }
        }

        public void ChangeVolume(float volume)
        {
            localVolume = volume;
            if(wavePlayer != null) wavePlayer.Volume = localVolume;
        }

        public void StopSong()
        {
            wavePlayer?.Stop();

            if (wavePlayer != null)
            {
                wavePlayer?.Dispose();
                wavePlayer = null;
            }
        }

        public void TogglePauseSong()
        {
            if(wavePlayer != null)
            {
                if (wavePlayer.PlaybackState == PlaybackState.Playing)
                {
                    wavePlayer.Pause();
                    return;
                }

                if (wavePlayer.PlaybackState == PlaybackState.Paused)
                {
                    wavePlayer.Play();
                    return;
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ToggleLoop()
        {
            if (enableLooping)
            {
                enableLooping = false;
            }
            if (!enableLooping)
            {
                enableLooping = true;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            if (wavePlayer != null)
            {
                wavePlayer?.Dispose();
                wavePlayer = null;
                audioFile?.Dispose();
                audioFile = null;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            if(!enableLooping && currentItem != null)
            {
                MainWindow.ChangeSong = true;
            }
        }

        public PlaybackState GetPlaybackState(PlaybackState playbackState)
        {
            if (wavePlayer == null) return PlaybackState.Stopped;

            playbackState = wavePlayer.PlaybackState;

            return playbackState;
        }
    }
}
