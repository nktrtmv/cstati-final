using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendPaymentTelegramMessages;

public sealed class SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService : CstatiEventsWorkflowsGuestsServiceClientBase
{
    public SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests)
        : base(guests)
    {
    }

    public async Task<SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponseBff> SendPaymentTelegramMessages(
        SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommand command =
            SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandBffConverter.ToDto(commandBff);

        await Guests.SendPaymentTelegramMessagesAsync(command, cancellationToken: cancellationToken);

        return SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponseBff.Instance;
    }
}
