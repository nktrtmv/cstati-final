using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Delete.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.TicketsTypes;

namespace Cstati.Events.Workflows.Presentation.Controllers.Tickets.Commands.Delete;

internal static class DeleteCstatiEventsWorkflowsTicketsCommandConverter
{
    internal static DeleteCstatiEventsWorkflowsTicketsCommandInternal ToInternal(DeleteCstatiEventsWorkflowsTicketsCommand command)
    {
        CstatiEventWorkflowTicketTypeInternal ticketType = CstatiEventWorkflowTicketTypeDtoConverter.ToInternal(command.TicketType);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteCstatiEventsWorkflowsTicketsCommandInternal(command.EventId, command.WaveOrdinal, ticketType, concurrencyToken);

        return result;
    }
}
