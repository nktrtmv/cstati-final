using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Application.Common.Tickets.Types;

internal static class CstatiEventWorkflowTicketTypeInternalConverter
{
    internal static CstatiEventWorkflowTicketTypeInternal FromDomain(CstatiEventWorkflowTicketType ticketType)
    {
        CstatiEventWorkflowTicketTypeInternal result = ticketType switch
        {
            CstatiEventWorkflowTicketType.Standard => CstatiEventWorkflowTicketTypeInternal.Standard,
            CstatiEventWorkflowTicketType.Comfort => CstatiEventWorkflowTicketTypeInternal.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(ticketType)
        };

        return result;
    }

    internal static CstatiEventWorkflowTicketType ToDomain(CstatiEventWorkflowTicketTypeInternal ticketType)
    {
        CstatiEventWorkflowTicketType result = ticketType switch
        {
            CstatiEventWorkflowTicketTypeInternal.Standard => CstatiEventWorkflowTicketType.Standard,
            CstatiEventWorkflowTicketTypeInternal.Comfort => CstatiEventWorkflowTicketType.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(ticketType)
        };

        return result;
    }
}
