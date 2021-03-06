﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace SimpleAudioPlayer.RPCHelper
{
    public class RPCHelper
    {
        public string ClientID;

        public static DiscordRpcClient client;
        public RichPresence discordPresence;

        public DateTime currentTimestamp = new DateTime();
        public Timestamps Timestamp = new Timestamps();

        internal void StartupRPC()
        {
            discordPresence = new RichPresence();

            discordPresence.State = "Not listening to anything";
            discordPresence.Details = "In song list";

            discordPresence.Assets = new Assets()
            {
                LargeImageKey = "logo2",
                LargeImageText = "Idle",
                SmallImageKey = "",
                SmallImageText = "File Origin: null",
            };

            client.SetPresence(discordPresence);
        }

        internal void EditRPC(string state, string details, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText)
        {
            discordPresence = new RichPresence();

            discordPresence.State = state;
            discordPresence.Details = details;

            discordPresence.Assets = new Assets()
            {
                LargeImageKey = largeImageKey,
                LargeImageText = largeImageText,
                SmallImageKey = smallImageKey,
                SmallImageText = smallImageText,
            };

            client.SetPresence(discordPresence);
        }

        //internal void EditDetails(string song, string projectLocation)
        //{
        //    discordPresence = new RichPresence();

        //    discordPresence.State = song;
        //    discordPresence.Details = projectLocation;

        //    client.SetPresence(discordPresence);
        //}

        //internal void EditImageKeys(string largeImageKey, string smallImageKey)
        //{
        //    discordPresence = new RichPresence();

        //    if (largeImageKey == null)
        //    {
        //        discordPresence.Assets.LargeImageKey = discordPresence.Assets.LargeImageKey;
        //    }
        //    else
        //    {
        //        discordPresence.Assets.LargeImageKey = largeImageKey;

        //    }

        //    if (smallImageKey == null)
        //    {
        //        discordPresence.Assets.SmallImageKey = discordPresence.Assets.SmallImageKey;
        //    }
        //    else
        //    {
        //        discordPresence.Assets.SmallImageKey = smallImageKey;

        //    }

        //    client.SetPresence(discordPresence);
        //}

        //internal void EditImage(string largeImageText, string smallImageText)
        //{
        //    discordPresence = new RichPresence();

        //    discordPresence.Assets.LargeImageText = largeImageText;
        //    discordPresence.Assets.SmallImageText = smallImageText;

        //    client.SetPresence(discordPresence);
        //}

        //internal void SetTimestamp(Timestamps ts)
        //{
        //    discordPresence = new RichPresence();

        //    discordPresence.WithTimestamps(ts);

        //    client.SetPresence(discordPresence);
        //}

        internal void Initialize(string clientID = "777219297524318280")
        {
            ClientID = clientID;

            client = new DiscordRpcClient(clientID);

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "In song list",
                State = "Not listening to anything",
                Assets = new Assets()
                {
                    LargeImageKey = "logo2",
                    LargeImageText = "Idle",
                    SmallImageKey = "image_small"
                }
            });
        }

    }
}
