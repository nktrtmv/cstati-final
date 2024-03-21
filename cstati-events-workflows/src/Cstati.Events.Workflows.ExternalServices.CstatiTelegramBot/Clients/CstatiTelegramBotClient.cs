using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Clients.Converters.Messages;
using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Contracts.Messages;
using Cstati.Events.Workflows.GenericSubdomain.Tracing;
using Cstati.Telegram.Bot.Api;

using Microsoft.Extensions.Logging;

namespace Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Clients;

internal sealed class CstatiTelegramBotClient : ICstatiTelegramBotClient
{
    public CstatiTelegramBotClient(CstatiTelegramBotService.CstatiTelegramBotServiceClient telegramBot, ILogger<CstatiTelegramBotClient> logger)
    {
        TelegramBot = telegramBot;
        Logger = logger;
    }

    private CstatiTelegramBotService.CstatiTelegramBotServiceClient TelegramBot { get; }
    private ILogger<CstatiTelegramBotClient> Logger { get; }

    public Task SendMessages(IReadOnlyCollection<CstatiTelegramBotMessageExternal> messagesExternal, CancellationToken cancellationToken)
    {
        SendMessageCstatiTelegramBotRequestMessage[] messages =
            messagesExternal.Select(SendMessageCstatiTelegramBotRequestMessageConverter.FromExternal).ToArray();

        var request = new SendMessageCstatiTelegramBotRequest
        {
            Messages = { messages }
        };

        return TracingFacility.TraceGrpc(
            Logger,
            nameof(SendMessages),
            request,
            async () => await TelegramBot.SendMessageAsync(request, cancellationToken: cancellationToken));
    }
}
