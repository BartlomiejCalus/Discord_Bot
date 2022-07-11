using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;

namespace dscBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public async Task RunA() 
        {
            var conf = new DiscordConfiguration
            {
                Token = "OTk2MTU0OTEwOTg5MDk5MDA5.GeEaKi.XdaOULrJoSPSrlH5hcyjolFlHzM-ADS-A0axNM",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                
            };

            Client = new DiscordClient(conf);
            Client.Ready += OnClientReady;

            var commandsConf = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "%" },
                EnableDms = false
                
            };
            Commands = Client.UseCommandsNext(commandsConf);

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }
        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {  
            return Task.CompletedTask;
        }
    }
}
