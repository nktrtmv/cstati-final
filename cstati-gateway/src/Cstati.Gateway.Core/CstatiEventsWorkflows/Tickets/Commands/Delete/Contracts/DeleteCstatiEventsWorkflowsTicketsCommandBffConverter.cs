using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Delete.Contracts;

internal static class DeleteCstatiEventsWorkflowsTicketsCommandBffConverter
{
    internal static DeleteCstatiEventsWorkflowsTicketsCommand ToDto(DeleteCstatiEventsWorkflowsTicketsCommandBff command)
    {
        CstatiEventWorkflowTicketTypeDto ticketType = CstatiEventWorkflowTicketTypeBffConverter.ToDto(command.TicketType);

        var result = new DeleteCstatiEventsWorkflowsTicketsCommand
        {
            EventId = command.EventId,
            WaveOrdinal = command.WaveOrdinal,
            TicketType = ticketType,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
