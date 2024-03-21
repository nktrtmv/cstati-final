using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Contracts.PaymentsCollectors.Banks;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Update.Contracts;

internal static class UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandBffConverter
{
    internal static UpdateCstatiEventsWorkflowsPaymentsCollectorsCommand ToDto(UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandBff command)
    {
        CstatiEventWorkflowPaymentCollectorBankDto preferredBank =
            CstatiEventWorkflowPaymentCollectorBankBffConverter.ToDto(command.PreferredBank);

        var result = new UpdateCstatiEventsWorkflowsPaymentsCollectorsCommand
        {
            EventId = command.EventId,
            PersonLogin = command.PersonLogin,
            PreferredBank = preferredBank,
            PhoneNumber = command.PhoneNumber,
            CardNumber = command.CardNumber,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
