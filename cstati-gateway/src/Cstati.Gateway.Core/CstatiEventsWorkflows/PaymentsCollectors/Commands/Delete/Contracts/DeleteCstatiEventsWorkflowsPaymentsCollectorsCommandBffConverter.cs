using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Delete.Contracts;

internal static class DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandBffConverter
{
    internal static DeleteCstatiEventsWorkflowsPaymentsCollectorsCommand ToDto(DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandBff command)
    {
        var result = new DeleteCstatiEventsWorkflowsPaymentsCollectorsCommand
        {
            EventId = command.EventId,
            PersonLogin = command.PersonLogin,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
