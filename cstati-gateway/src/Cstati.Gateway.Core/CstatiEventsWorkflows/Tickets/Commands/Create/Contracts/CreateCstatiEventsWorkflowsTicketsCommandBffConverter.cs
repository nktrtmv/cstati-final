using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Create.Contracts;

internal static class CreateCstatiEventsWorkflowsTicketsCommandBffConverter
{
    internal static CreateCstatiEventsWorkflowsTicketsCommand ToDto(CreateCstatiEventsWorkflowsTicketsCommandBff command)
    {
        CstatiEventWorkflowTicketTypeDto ticketType = CstatiEventWorkflowTicketTypeBffConverter.ToDto(command.TicketType);

        var result = new CreateCstatiEventsWorkflowsTicketsCommand
        {
            EventId = command.EventId,
            WaveOrdinal = command.WaveOrdinal,
            TicketType = ticketType,
            Price = command.Price,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
