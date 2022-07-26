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
using DSharpPlus.Lavalink;
using DSharpPlus.Lavalink.Entities;
using DSharpPlus.Net;

namespace dscBot
{
    
    public class MusicCommands : BaseCommandModule
    {

        [Command("play")]
        public async Task Play(CommandContext ctx, Uri url)
        {
            

            

            if (ctx.Member.VoiceState == null || ctx.Member.VoiceState.Channel == null)
            {
                return;
            }

            var lava = ctx.Client.GetLavalink();
            var node = lava.ConnectedNodes.Values.First();
            var conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);


            if (conn == null)   //jeśli bot nie jest połączony
            {  
                await node.ConnectAsync(ctx.Member.VoiceState.Channel).ConfigureAwait(false);
                conn = node.GetGuildConnection(ctx.Member.VoiceState.Guild);
            }else if (ctx.Member.VoiceState.Channel != conn.Channel)    //jeśli jetseś na innym kanale niż bot
            {
                await ctx.RespondAsync("Bot jest na innym kanale").ConfigureAwait(false);
                return;
            }
            

            var loadResult = await node.Rest.GetTracksAsync(url).ConfigureAwait(false);

            if (loadResult.LoadResultType == LavalinkLoadResultType.LoadFailed)
            {
                await ctx.RespondAsync($"Nie udana próba połaczenia z {url}.").ConfigureAwait(false);
                return;

            }else if (loadResult.LoadResultType == LavalinkLoadResultType.NoMatches)
            {
                await ctx.RespondAsync($"Brak pasujących rozwiązań do  {url}").ConfigureAwait(false);
                return;
            }

            var listTracks = loadResult.Tracks.ToList();

            var tracks = loadResult.LoadResultType == LavalinkLoadResultType.PlaylistLoaded
                ? listTracks
                : listTracks.Take(Math.Min(10, listTracks.Count)).ToList();

            foreach (var track in tracks) MyQueue.addTruck(track);

            
                if (conn.CurrentState.CurrentTrack == null)
                {
                    for (int i = 0; i < MyQueue.it(); ++i)
                    {
                        var song = MyQueue.getTruck();
                        if (song != null)
                        {
                            await conn.PlayAsync(song).ConfigureAwait(false);
                            await ctx.RespondAsync($"Właśnie słuchamy \n{song.Title}!").ConfigureAwait(false);
                        }
                    
                    }
                }
                else
                {
                    await ctx.RespondAsync(MyQueue.playList()).ConfigureAwait(false);

                }

            

        }

        [Command("leave")]
        public async Task Leave(CommandContext ctx)
        {
            var conn = ctx.Client.GetLavalink()
                .ConnectedNodes.Values.First()
                .GetGuildConnection(ctx.Channel.Guild);

            if(conn != null) 
                await conn.DisconnectAsync().ConfigureAwait(false);
        }

        [Command("next")]
        public async Task GetNext(CommandContext ctx)
        {
            var conn = ctx.Client.GetLavalink()
                .ConnectedNodes.Values.First()
                .GetGuildConnection(ctx.Channel.Guild);

            if (conn != null)
                await conn.PlayAsync(MyQueue.getTruck()).ConfigureAwait(false);
        }
        [Command("queue")]
        public async Task PlayList(CommandContext ctx)
        {
            var conn = ctx.Client.GetLavalink()
                .ConnectedNodes.Values.First()
                .GetGuildConnection(ctx.Channel.Guild);

            if (conn != null)
                await conn.Channel.SendMessageAsync(MyQueue.playList());
        }
    }
}
