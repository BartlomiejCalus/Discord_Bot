using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Net;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace dscBot
{
    public class MyCommands : BaseCommandModule
    {

        [Command("Hubert")]
        [Description("DOBRZE HUBERT !")]
        public async Task Hubert (CommandContext ctx)
        {

            if (ctx.Channel.Name != "testy")
            {
                return;
            }

            await ctx.RespondAsync("Dobrze Hubert").ConfigureAwait(false);
        }

        [Command("Role")]
        public async Task Role(CommandContext ctx)
        {

            if (ctx.Channel.Name != "testy")
            {
                return;
            }

            TimeSpan duration = TimeSpan.FromSeconds(10);
            var roleEmbed = new DiscordEmbedBuilder
            {
                Title = "Wybierz swoje role",
                Description = $":wastebasket: - Leauge of Legends\n" +
                $":gun: - cs go\n" +
                $":child: - Fortnite",
                Color = DiscordColor.Red
            };

            var wbEmoji = DiscordEmoji.FromName(ctx.Client, ":wastebasket:");
            var gEmoji = DiscordEmoji.FromName(ctx.Client, ":gun:");
            var cEmoji = DiscordEmoji.FromName(ctx.Client, ":child:");
            var sunEmoji = DiscordEmoji.FromName(ctx.Client, ":sunglasses:");

            var roleMes = await ctx.Channel.SendMessageAsync(embed: roleEmbed).ConfigureAwait(false);

            await roleMes.CreateReactionAsync(wbEmoji).ConfigureAwait(false);
            await roleMes.CreateReactionAsync(gEmoji).ConfigureAwait(false);
            await roleMes.CreateReactionAsync(cEmoji).ConfigureAwait(false);
            await roleMes.CreateReactionAsync(sunEmoji).ConfigureAwait(false);

            var interac = ctx.Client.GetInteractivity();

            var result = await interac.CollectReactionsAsync(roleMes,duration).ConfigureAwait(false);

            var results = result.Select(x => x.Emoji).ToList();

            foreach(var r in results)
            if (r == wbEmoji)
            {
                var role = ctx.Guild.GetRole(1001519748867178616);
                await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);

            }
            else if(r == gEmoji)
            {
                var role = ctx.Guild.GetRole(1001519758652489809);
                await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);

            }
            else if(r == cEmoji)
            {
                var role = ctx.Guild.GetRole(1001519903582453870);
                await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);

            }else if(r == cEmoji)
            {
                var role = ctx.Guild.GetRole(1001519903582453870);
                await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);

            }else if (r == sunEmoji)
            {
                var role = ctx.Guild.GetRole(1001533009733881957);
                await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);

            }else
            {
                await roleMes.DeleteReactionAsync(r, ctx.Member).ConfigureAwait(false);
            }
            
        }

    }
}
