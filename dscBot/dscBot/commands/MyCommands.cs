using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;

namespace dscBot
{
    public class MyCommands : BaseCommandModule
    {

        [Command("Hubert")]
        [Description("DOBRZE HUBERT !")]
        public async Task Hubert (CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Dobrze Hubert").ConfigureAwait(false);
        }

        [Command("join")]
        public async Task join (CommandContext ctx)
        {
            DiscordChannel channel;

            var voice = ctx.Client.GetVoiceNext();
            var voiceStat = ctx.Member?.VoiceState;

            if(voiceStat?.Channel != null)
            {
                channel = voiceStat.Channel;
                await voice.ConnectAsync(channel).ConfigureAwait(false);
            }
            
        }

    }
}
