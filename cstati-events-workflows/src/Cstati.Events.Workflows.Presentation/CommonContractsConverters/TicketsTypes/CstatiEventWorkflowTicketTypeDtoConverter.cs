using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.CommonContractsConverters.TicketsTypes;

internal static class CstatiEventWorkflowTicketTypeDtoConverter
{
    internal static CstatiEventWorkflowTicketTypeDto FromInternal(CstatiEventWorkflowTicketTypeInternal type)
    {
        CstatiEventWorkflowTicketTypeDto result = type switch
        {
            CstatiEventWorkflowTicketTypeInternal.Standard => CstatiEventWorkflowTicketTypeDto.Standard,
            CstatiEventWorkflowTicketTypeInternal.Comfort => CstatiEventWorkflowTicketTypeDto.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static CstatiEventWorkflowTicketTypeInternal ToInternal(CstatiEventWorkflowTicketTypeDto type)
    {
        CstatiEventWorkflowTicketTypeInternal result = type switch
        {
            CstatiEventWorkflowTicketTypeDto.Standard => CstatiEventWorkflowTicketTypeInternal.Standard,
            CstatiEventWorkflowTicketTypeDto.Comfort => CstatiEventWorkflowTicketTypeInternal.Comfort,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
