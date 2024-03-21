using Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Start.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.Start;

internal static class StartCstatiEventsWorkflowsEventConverter
{
    internal static StartCstatiEventsWorkflowsEventInternal ToInternal(CstatiEventsWorkflowsEventValue value)
    {
        var result = new StartCstatiEventsWorkflowsEventInternal(value.EventId);

        return result;
    }
}
