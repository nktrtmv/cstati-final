using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsTicketsCommandInternal : IRequest
{
    public DeleteCstatiEventsWorkflowsTicketsCommandInternal(
        string eventId,
        int waveOrdinal,
        CstatiEventWorkflowTicketTypeInternal ticketType,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        WaveOrdinal = waveOrdinal;
        TicketType = ticketType;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal int WaveOrdinal { get; }
    internal CstatiEventWorkflowTicketTypeInternal TicketType { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
