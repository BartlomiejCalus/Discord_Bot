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
                Token = "OTk2MTU0OTEwOTg5MDk5MDA5.Gvf-6k.7P4ERvecSrZuNOKali6NDxwKzch52-Vx36BN5w",
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
