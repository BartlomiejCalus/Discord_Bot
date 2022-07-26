using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.VoiceNext;
using DSharpPlus.Lavalink;
using DSharpPlus.Net;

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
                Token = "####",
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                
            };

            var commandsConf = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { "%" },
                EnableDms = false
                
            };

            var endPoint = new ConnectionEndpoint
            {
                Hostname = "127.0.0.1",
                Port = 2332
            };

            var lavaConf = new LavalinkConfiguration
            {
                Password = "youshallnotpass",
                RestEndpoint = endPoint,
                SocketEndpoint = endPoint
            };

            Client = new DiscordClient(conf);
            
            Client.Ready += OnClientReady;

            Commands = Client.UseCommandsNext(commandsConf);

            Commands.RegisterCommands<MyCommands>();
            Commands.RegisterCommands<MusicCommands>();

            voice = Client.UseVoiceNext();

            var lavaLink = Client.UseLavalink();

            await Client.ConnectAsync();

            await lavaLink.ConnectAsync(lavaConf);

            await Task.Delay(-1);
        }
        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {  
            return Task.CompletedTask;
        }
    }
}
