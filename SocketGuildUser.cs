//File: Bot Original / SocketGuildUser.cs
//Author: Michele Biondi
//Date: Last Updatet on February 15, 2020
//Description: SocketGuildUser for the Discord Bot

using System;
using System.Threading.Tasks;


namespace Bot_Commands.Bot_Commands
{
    public class SocketGuildUser
    {
        public object Username { get; internal set; }

        internal Task GetOrCreateDMChannelAsync(string v)
        {
            throw new NotImplementedException();
        }

        internal Task KickAsync()
        {
            throw new NotImplementedException();
        }

        internal Task CreateDMChannelAsync()
        {
            throw new NotImplementedException();
        }

        internal Task GetOrCreateDMChannelAsync()
        {
            throw new NotImplementedException();
        }
    }
}
