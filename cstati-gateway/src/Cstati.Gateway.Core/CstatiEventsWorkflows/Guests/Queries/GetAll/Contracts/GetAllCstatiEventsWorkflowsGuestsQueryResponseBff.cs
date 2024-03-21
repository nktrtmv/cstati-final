using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseBff
{
    public required GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestBff[] Guests { get; init; }
    public required string ConcurrencyToken { get; init; }
}
