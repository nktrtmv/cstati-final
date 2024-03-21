using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Contracts.Messages;

namespace Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot;

public interface ICstatiTelegramBotClient
{
    Task SendMessages(IReadOnlyCollection<CstatiTelegramBotMessageExternal> messagesExternal, CancellationToken cancellationToken);
}
