namespace Watermelon.Services
{
    using Discord.Addons.Hosting;
    using Discord.WebSocket;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Watermelon.Data;

    /// <summary>
    /// A custom implementation of <see cref="DiscordClientService"/> for Watermelon.
    /// </summary>
    public abstract class WatermelonService : DiscordClientService
    {
        public readonly DiscordSocketClient Client;
        public readonly ILogger<DiscordClientService> Logger;
        public readonly IConfiguration Configuration;
        public readonly DataAccessLayer DataAccessLayer;

        public WatermelonService(DiscordSocketClient client, ILogger<DiscordClientService> logger, IConfiguration configuration, DataAccessLayer dataAccessLayer)
            : base(client, logger)
        {
            Client = client;
            Logger = logger;
            Configuration = configuration;
            DataAccessLayer = dataAccessLayer;
        }
    }
}
