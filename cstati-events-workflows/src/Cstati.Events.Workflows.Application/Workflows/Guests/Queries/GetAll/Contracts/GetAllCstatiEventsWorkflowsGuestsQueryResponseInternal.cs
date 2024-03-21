using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal
{
    public GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal[] guests, ConcurrencyToken concurrencyToken)
    {
        Guests = guests;
        ConcurrencyToken = concurrencyToken;
    }

    public GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal[] Guests { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
