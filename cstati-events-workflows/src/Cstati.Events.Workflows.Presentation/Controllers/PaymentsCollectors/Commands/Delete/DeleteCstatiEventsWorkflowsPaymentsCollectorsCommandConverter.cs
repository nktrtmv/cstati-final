using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Delete.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Commands.Delete;

internal static class DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandConverter
{
    internal static DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternal ToInternal(DeleteCstatiEventsWorkflowsPaymentsCollectorsCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternal(command.EventId, command.PersonLogin, concurrencyToken);

        return result;
    }
}
