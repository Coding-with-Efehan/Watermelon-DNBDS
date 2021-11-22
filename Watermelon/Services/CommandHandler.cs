namespace Watermelon.Services
{
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Discord;
    using Discord.Addons.Hosting;
    using Discord.Commands;
    using Discord.WebSocket;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Watermelon.Data;

    /// <summary>
    /// The class responsible for handling the commands and various events.
    /// </summary>
    public class CommandHandler : WatermelonService
    {
        private readonly IServiceProvider _provider;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _service;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> that should be injected.</param>
        /// <param name="client">The <see cref="DiscordSocketClient"/> that should be injected.</param>
        /// <param name="service">The <see cref="CommandService"/> that should be injected.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> that should be injected.</param>
        public CommandHandler(IServiceProvider provider, DiscordSocketClient client, CommandService service, IConfiguration configuration, ILogger<DiscordClientService> logger, DataAccessLayer dataAccessLayer)
            : base(client, logger, configuration, dataAccessLayer)
        {
            _provider = provider;
            _client = client;
            _service = service;
            _configuration = configuration;
        }

        /// <inheritdoc/>
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _client.MessageReceived += OnMessageReceived;
            _service.CommandExecuted += OnCommandExecuted;
            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }

        private async Task OnCommandExecuted(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
        {
            if (result.IsSuccess)
            {
                return;
            }

            await commandContext.Channel.SendMessageAsync(result.ErrorReason);
        }

        private async Task OnMessageReceived(SocketMessage socketMessage)
        {
            if (!(socketMessage is SocketUserMessage message))
            {
                return;
            }

            if (message.Source != MessageSource.User)
            {
                return;
            }

            var argPos = 0;
            var user = message.Author as SocketGuildUser;
            var prefix = DataAccessLayer.GetPrefix(user.Guild.Id);
            if (!message.HasStringPrefix(prefix, ref argPos) && !message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                return;
            }

            var context = new SocketCommandContext(_client, message);
            await _service.ExecuteAsync(context, argPos, _provider);
        }
    }
}
