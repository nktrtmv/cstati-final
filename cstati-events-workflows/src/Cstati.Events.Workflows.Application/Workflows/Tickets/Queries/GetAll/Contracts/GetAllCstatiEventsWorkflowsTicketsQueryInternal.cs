using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsTicketsQueryInternal : IRequest<GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsTicketsQueryInternal(string eventId, int waveOrdinal)
    {
        EventId = eventId;
        WaveOrdinal = waveOrdinal;
    }

    internal string EventId { get; }
    internal int WaveOrdinal { get; }
}
