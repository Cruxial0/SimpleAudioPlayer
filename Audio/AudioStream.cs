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

        private LoopStream LS;

        public void PlaySong(string filePath)
        {
            if (wavePlayer == null)
            {
                wavePlayer = new WaveOutEvent();
                audioFile = new AudioFileReader(filePath);

                LS = new LoopStream(audioFile);

                audioFile.Volume = localVolume;
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
            if(audioFile != null) audioFile.Volume = localVolume;
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
            if(wavePlayer != null) wavePlayer.Dispose();

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
