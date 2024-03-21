using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets.Types;

internal static class CstatiEventWorkflowTicketTypeDbConverter
{
    internal static CstatiEventWorkflowTicketTypeDb FromDomain(CstatiEventWorkflowTicketType type)
    {
        CstatiEventWorkflowTicketTypeDb result = type switch
        {
            CstatiEventWorkflowTicketType.Standard => CstatiEventWorkflowTicketTypeDb.Standard,
            CstatiEventWorkflowTicketType.Comfort => CstatiEventWorkflowTicketTypeDb.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static CstatiEventWorkflowTicketType ToDomain(CstatiEventWorkflowTicketTypeDb type)
    {
        CstatiEventWorkflowTicketType result = type switch
        {
            CstatiEventWorkflowTicketTypeDb.Standard => CstatiEventWorkflowTicketType.Standard,
            CstatiEventWorkflowTicketTypeDb.Comfort => CstatiEventWorkflowTicketType.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
