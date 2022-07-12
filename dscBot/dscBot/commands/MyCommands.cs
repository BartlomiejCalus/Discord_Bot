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
        [Description("used to join voice cannel")]
        public async Task join (CommandContext ctx)
        {

            var voice = ctx.Client.GetVoiceNext();
            var chConnetcted = voice.GetConnection(ctx.Guild);
            var voiceStat = ctx.Member?.VoiceState;

            if (chConnetcted != null && chConnetcted.TargetChannel != voiceStat?.Channel)
            {
                chConnetcted.Disconnect();
            }

            if (voiceStat?.Channel != null)
            {
                await voice.ConnectAsync(voiceStat.Channel).ConfigureAwait(false);
            }
            
        }

        [Command("leave")]
        [Description("used to leave voice cannel")]
        public async Task leave (CommandContext ctx)
        {
            var chConnetcted = ctx.Client.GetVoiceNext()
                .GetConnection(ctx.Guild);

            if (chConnetcted != null) chConnetcted.Disconnect();
        }

    }
}
