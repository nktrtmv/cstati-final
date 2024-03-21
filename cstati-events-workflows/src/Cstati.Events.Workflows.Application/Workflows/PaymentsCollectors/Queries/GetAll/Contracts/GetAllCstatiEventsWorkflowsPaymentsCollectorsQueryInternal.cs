using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternal : IRequest<GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternal(string eventId)
    {
        EventId = eventId;
    }

    internal string EventId { get; }
}
