namespace Watermelon.Modules
{
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Discord.Rest;
    using Watermelon.Data;

    /// <summary>
    /// The custom implementation of <see cref="ModuleBase{T}"/> for Watermelon.
    /// </summary>
    public abstract class WatermelonModuleBase : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// The <see cref="DataAccessLayer"/> of Watermelon.
        /// </summary>
        public readonly DataAccessLayer DataAccessLayer;

        public string Prefix
        {
            get
            {
                if (string.IsNullOrEmpty(_prefix))
                {
                    _prefix = DataAccessLayer.GetPrefix(Context.Guild.Id);
                }

                return _prefix;
            }
        }

        private string _prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatermelonModuleBase"/> class.
        /// </summary>
        /// <param name="dataAccessLayer">The <see cref="DataAccessLayer"/> to inject.</param>
        public WatermelonModuleBase(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        /// <summary>
        /// Send an embed containing a title and description to a channel.
        /// </summary>
        /// <param name="title">The title of the embed.</param>
        /// <param name="description">The description of the embed.</param>
        /// <returns>A <see cref="RestUserMessage"/> containing the embed.</returns>
        public async Task<RestUserMessage> SendEmbedAsync(string title, string description)
        {
            var builder = new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description);

            return await Context.Channel.SendMessageAsync(embed: builder.Build());
        }
    }
}
