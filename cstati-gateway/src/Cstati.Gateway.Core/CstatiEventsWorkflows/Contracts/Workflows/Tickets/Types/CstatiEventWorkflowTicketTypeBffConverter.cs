using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;

internal static class CstatiEventWorkflowTicketTypeBffConverter
{
    internal static CstatiEventWorkflowTicketTypeBff FromDto(CstatiEventWorkflowTicketTypeDto type)
    {
        CstatiEventWorkflowTicketTypeBff result = type switch
        {
            CstatiEventWorkflowTicketTypeDto.Standard => CstatiEventWorkflowTicketTypeBff.Standard,
            CstatiEventWorkflowTicketTypeDto.Comfort => CstatiEventWorkflowTicketTypeBff.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static CstatiEventWorkflowTicketTypeDto ToDto(CstatiEventWorkflowTicketTypeBff type)
    {
        CstatiEventWorkflowTicketTypeDto result = type switch
        {
            CstatiEventWorkflowTicketTypeBff.Standard => CstatiEventWorkflowTicketTypeDto.Standard,
            CstatiEventWorkflowTicketTypeBff.Comfort => CstatiEventWorkflowTicketTypeDto.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
