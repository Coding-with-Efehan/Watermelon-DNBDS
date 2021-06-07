namespace Watermelon.Modules
{
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;

    /// <summary>
    /// The general module containing commands like ping.
    /// </summary>
    public class General : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// A command that will respond with pong.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("ping")]
        [Alias("p")]
        public async Task PingAsync()
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.Context.Channel.SendMessageAsync("Pong!");
        }

        /// <summary>
        /// A command to get some information about a user.
        /// </summary>
        /// <param name="socketGuildUser">An optional user to get the information from.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("info")]
        public async Task InfoAsync(SocketGuildUser socketGuildUser = null)
        {
            if (socketGuildUser == null)
            {
                socketGuildUser = this.Context.User as SocketGuildUser;
            }

            await this.ReplyAsync($"ID: {socketGuildUser.Id}\n" +
                $"Name: {socketGuildUser.Username}#{socketGuildUser.Discriminator}\n" +
                $"Created at: {socketGuildUser.CreatedAt}");
        }
    }
}
