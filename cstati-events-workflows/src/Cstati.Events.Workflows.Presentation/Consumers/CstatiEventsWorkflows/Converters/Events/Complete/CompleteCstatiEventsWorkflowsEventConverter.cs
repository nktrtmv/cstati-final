using Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Complete.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.Complete;

internal static class CompleteCstatiEventsWorkflowsEventConverter
{
    internal static CompleteCstatiEventsWorkflowsEventInternal ToInternal(CstatiEventsWorkflowsEventValue value)
    {
        var result = new CompleteCstatiEventsWorkflowsEventInternal(value.EventId);

        return result;
    }
}
