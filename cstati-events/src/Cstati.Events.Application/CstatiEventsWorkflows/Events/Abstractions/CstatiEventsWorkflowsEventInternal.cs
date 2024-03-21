using MediatR;

namespace Cstati.Events.Application.CstatiEventsWorkflows.Events.Abstractions;

public abstract class CstatiEventsWorkflowsEventInternal : IRequest
{
    protected CstatiEventsWorkflowsEventInternal(string eventId)
    {
        EventId = eventId;
    }

    public string EventId { get; }
}
