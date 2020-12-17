using DiscordRPC;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.Audio
{
    class LoopStream : WaveStream
    {
        WaveStream sourceStream;

        private DateTime currentTimestamp = new DateTime();
        private Timestamps Timestamp = new Timestamps();

        private readonly RPCHelper.RPCHelper RPC = new RPCHelper.RPCHelper();

        public LoopStream(WaveStream sourceStream, bool enableLooping)
        {
            this.sourceStream = sourceStream;
            EnableLooping = enableLooping;
        }

        public bool EnableLooping { get; set; }

        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        public override long Length
        {
            get { return sourceStream.Length; }
        }

        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count && EnableLooping)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }

    }
}
