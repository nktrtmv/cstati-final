using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Create.Contracts;

public sealed class CreateCstatiEventsWorkflowsTicketsCommandInternal : IRequest
{
    public CreateCstatiEventsWorkflowsTicketsCommandInternal(
        string eventId,
        int waveOrdinal,
        CstatiEventWorkflowTicketTypeInternal ticketType,
        double price,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        WaveOrdinal = waveOrdinal;
        TicketType = ticketType;
        Price = price;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal int WaveOrdinal { get; }
    internal CstatiEventWorkflowTicketTypeInternal TicketType { get; }
    internal double Price { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
