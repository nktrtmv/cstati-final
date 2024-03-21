using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendTelegramMessages.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendTelegramMessages;

public sealed class SendTelegramMessagesCstatiEventsWorkflowsGuestsService : CstatiEventsWorkflowsGuestsServiceClientBase
{
    public SendTelegramMessagesCstatiEventsWorkflowsGuestsService(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests) : base(guests)
    {
    }

    public async Task<SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponseBff> SendTelegramMessages(
        SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        SendTelegramMessagesCstatiEventsWorkflowsGuestsCommand command = SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandBffConverter.ToDto(commandBff);

        await Guests.SendTelegramMessagesAsync(command, cancellationToken: cancellationToken);

        return SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponseBff.Instance;
    }
}
