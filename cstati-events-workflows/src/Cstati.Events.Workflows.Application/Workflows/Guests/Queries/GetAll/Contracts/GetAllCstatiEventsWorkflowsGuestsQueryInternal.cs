using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryInternal : IRequest<GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsGuestsQueryInternal(string eventId, int? waveOrdinal)
    {
        EventId = eventId;
        WaveOrdinal = waveOrdinal;
    }

    internal string EventId { get; }
    internal int? WaveOrdinal { get; }
}
