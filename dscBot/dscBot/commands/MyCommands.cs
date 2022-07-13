using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace dscBot
{
    public class MyCommands : BaseCommandModule
    {

        [Command("Hubert")]
        [Description("DOBRZE HUBERT !")]
        public async Task Hubert (CommandContext ctx)
        {
            await ctx.RespondAsync("Dobrze Hubert").ConfigureAwait(false);
        }

    }
}
