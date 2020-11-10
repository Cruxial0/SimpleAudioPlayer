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

        private LoopStream LS;

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
        }

        private void PlayMusicFile(PlaylistItem fileInfo)
        {
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
                audioFile = new AudioFileReader(fileInfo.filePath);

                audioFile.Volume = localVolume;

                LS = new LoopStream(audioFile);

                wavePlayer.Init(LS);
                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                wavePlayer.Play();
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

                LS = new LoopStream(mf);

                wavePlayer.Init(LS);
                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                wavePlayer.Play();
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
            wavePlayer?.Dispose();
            wavePlayer = null;
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
        }

        public void ToggleLoop()
        {
            if(LS.EnableLooping)
            {
                LS.EnableLooping = false;
            }
            if(!LS.EnableLooping)
            {
                LS.EnableLooping = true;
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            if(wavePlayer != null) wavePlayer?.Dispose();

            wavePlayer = null;
            audioFile?.Dispose();
            audioFile = null;
        }

        public PlaybackState GetPlaybackState(PlaybackState playbackState)
        {
            if (wavePlayer == null) return PlaybackState.Stopped;

            playbackState = wavePlayer.PlaybackState;
            return playbackState;
        }
    }
}
