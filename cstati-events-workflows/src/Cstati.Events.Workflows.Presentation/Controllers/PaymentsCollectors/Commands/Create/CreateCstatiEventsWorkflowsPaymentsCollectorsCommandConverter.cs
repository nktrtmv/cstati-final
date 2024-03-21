using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Create.Contracts;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Contracts.Banks;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Commands.Create;

internal static class CreateCstatiEventsWorkflowsPaymentsCollectorsCommandConverter
{
    internal static CreateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal ToInternal(CreateCstatiEventsWorkflowsPaymentsCollectorsCommand command)
    {
        CstatiEventWorkflowPaymentCollectorBankInternal preferredBank =
            CstatiEventWorkflowPaymentCollectorBankDtoConverter.ToInternal(command.PreferredBank);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new CreateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal(
            command.EventId,
            command.PersonLogin,
            preferredBank,
            command.PhoneNumber,
            command.CardNumber,
            concurrencyToken);

        return result;
    }
}
