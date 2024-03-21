using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsTicketsCommandBff
{
    public required string EventId { get; init; }
    public required int WaveOrdinal { get; init; }
    public required CstatiEventWorkflowTicketTypeBff TicketType { get; init; }
    public required string ConcurrencyToken { get; init; }
}
