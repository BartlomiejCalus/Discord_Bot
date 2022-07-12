using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.VoiceNext;

namespace dscBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public VoiceNextExtension voice {get; private set; }
    public async Task RunA() 
        {
            var conf = new DiscordConfiguration
            {
<<<<<<< HEAD
                Token = "OTk2MTU0OTEwOTg5MDk5MDA5.GAqE6G.hyWBuxeu3kk6x3vxS38gfQTXbNFotsqBAjNAno",
=======
                Token = "######",
>>>>>>> 066ef8c6907a4430e8690b356bc6b5252dff708f
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                
            };

            var commandsConf = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "%" },
                EnableDms = false
                
            };

            Client = new DiscordClient(conf);
            Client.Ready += OnClientReady;

            Commands = Client.UseCommandsNext(commandsConf);

            Commands.RegisterCommands<MyCommands>();

            voice = Client.UseVoiceNext();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }
        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {  
            return Task.CompletedTask;
        }
    }
}
