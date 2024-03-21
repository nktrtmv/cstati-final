using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Create.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.TicketsTypes;

namespace Cstati.Events.Workflows.Presentation.Controllers.Tickets.Commands.Create;

internal static class CreateCstatiEventsWorkflowsTicketsCommandConverter
{
    internal static CreateCstatiEventsWorkflowsTicketsCommandInternal ToInternal(CreateCstatiEventsWorkflowsTicketsCommand command)
    {
        CstatiEventWorkflowTicketTypeInternal ticketType = CstatiEventWorkflowTicketTypeDtoConverter.ToInternal(command.TicketType);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new CreateCstatiEventsWorkflowsTicketsCommandInternal(command.EventId, command.WaveOrdinal, ticketType, command.Price, concurrencyToken);

        return result;
    }
}
