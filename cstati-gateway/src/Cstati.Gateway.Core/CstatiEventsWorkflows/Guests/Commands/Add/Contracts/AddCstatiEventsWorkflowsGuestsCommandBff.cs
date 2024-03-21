using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add.Contracts.Guests;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add.Contracts;

public sealed class AddCstatiEventsWorkflowsGuestsCommandBff
{
    public required string EventId { get; init; }
    public required AddCstatiEventsWorkflowsGuestsCommandGuestBff Guest { get; init; }
    public required string ConcurrencyToken { get; init; }
}
