using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Contracts.PaymentsCollectors.Banks;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Create.Contracts;

internal static class CreateCstatiEventsWorkflowsPaymentsCollectorsCommandBffConverter
{
    internal static CreateCstatiEventsWorkflowsPaymentsCollectorsCommand ToDto(CreateCstatiEventsWorkflowsPaymentsCollectorsCommandBff command)
    {
        CstatiEventWorkflowPaymentCollectorBankDto preferredBank =
            CstatiEventWorkflowPaymentCollectorBankBffConverter.ToDto(command.PreferredBank);

        var result = new CreateCstatiEventsWorkflowsPaymentsCollectorsCommand
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
