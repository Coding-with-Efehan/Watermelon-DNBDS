using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Alias("p")]
        public async Task PingAsync()
        {
            await Context.Channel.TriggerTypingAsync();
            await Context.Channel.SendMessageAsync("Pong!");
            await Context.User.SendMessageAsync("Hey! This is a private message!");
        }

        [Command("info")]
        public async Task InfoAsync(SocketGuildUser socketGuildUser = null)
        {
            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }

            await ReplyAsync($"ID: {socketGuildUser.Id}\n" +
                $"Name: {socketGuildUser.Username}#{socketGuildUser.Discriminator}\n" +
                $"Created at: {socketGuildUser.CreatedAt}");
        }
    }
}
