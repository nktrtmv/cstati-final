using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsWavesQueryInternal : IRequest<GetAllCstatiEventsWorkflowsWavesQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsWavesQueryInternal(string eventId)
    {
        EventId = eventId;
    }

    public string EventId { get; }
}
