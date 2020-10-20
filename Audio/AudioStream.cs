using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
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
        private float localVolume;
        private AudioFileReader audioFile;

        private bool IsSongPlaying = false;

        public void PlaySong(string filePath)
        {
            if (IsSongPlaying)
            {
                StopSong();
            }

            if(wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
                audioFile = new AudioFileReader(filePath);
                audioFile.Volume = localVolume;
                wavePlayer.Init(audioFile);
                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                wavePlayer.Play();

                IsSongPlaying = true;
            }
        }

        public void ChangeVolume(float volume)
        {
            localVolume = volume;
            if(audioFile != null) audioFile.Volume = localVolume;
        }

        public void StopSong()
        {
            wavePlayer?.Stop();
            IsSongPlaying = false;
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

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            if(wavePlayer != null) wavePlayer.Dispose();

            wavePlayer = null;
            audioFile.Dispose();
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
