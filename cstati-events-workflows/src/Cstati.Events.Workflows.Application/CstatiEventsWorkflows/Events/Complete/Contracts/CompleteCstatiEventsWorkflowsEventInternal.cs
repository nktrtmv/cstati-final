using MediatR;

namespace Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Complete.Contracts;

public sealed class CompleteCstatiEventsWorkflowsEventInternal : IRequest
{
    public CompleteCstatiEventsWorkflowsEventInternal(string eventId)
    {
        EventId = eventId;
    }

    internal string EventId { get; }
}
