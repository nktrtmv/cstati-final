using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Update.Contracts;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Contracts.Banks;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Commands.Update;

internal static class UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandConverter
{
    internal static UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal ToInternal(UpdateCstatiEventsWorkflowsPaymentsCollectorsCommand command)
    {
        CstatiEventWorkflowPaymentCollectorBankInternal preferredBank =
            CstatiEventWorkflowPaymentCollectorBankDtoConverter.ToInternal(command.PreferredBank);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal(
            command.EventId,
            command.PersonLogin,
            preferredBank,
            command.PhoneNumber,
            command.CardNumber,
            concurrencyToken);

        return result;
    }
}
