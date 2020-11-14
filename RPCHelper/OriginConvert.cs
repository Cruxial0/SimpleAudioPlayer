using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAudioPlayer.RPCHelper
{
    public class OriginConvert
    {
        public string OriginToAssetName(string origin)
        {
            switch(origin)
            {
                case "osu!":
                    return "osuorigin";

                case "mp3":
                    return "mp3origin";

                default:
                    return string.Empty;
            }
        }

        internal string OriginToImageText(string origin)
        {
            switch (origin)
            {
                case "osu!":
                    return "File Origin: osu!";

                case "mp3":
                    return "File Origin: mp3";

                default:
                    return string.Empty;
            }
        }
    }
}

