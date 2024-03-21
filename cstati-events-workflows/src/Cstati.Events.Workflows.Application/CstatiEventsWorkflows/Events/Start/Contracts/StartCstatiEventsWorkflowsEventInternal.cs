using MediatR;

namespace Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Start.Contracts;

public sealed class StartCstatiEventsWorkflowsEventInternal : IRequest
{
    public StartCstatiEventsWorkflowsEventInternal(string eventId)
    {
        EventId = eventId;
    }

    internal string EventId { get; }
}
