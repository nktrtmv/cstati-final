using Cstati.Events.Application.CstatiEventsWorkflows.Events.Abstractions;
using Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.GuestsPaymentsStatusesChanged;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events;

internal static class CstatiEventsWorkflowsEventConverter
{
    internal static CstatiEventsWorkflowsEventInternal? ToInternal(CstatiEventsWorkflowsEventValue @event)
    {
        CstatiEventsWorkflowsEventInternal? result = @event.EventCase switch
        {
            CstatiEventsWorkflowsEventValue.EventOneofCase.GuestPaymentStatusChanged =>
                GuestPaymentStatusChangedCstatiEventsWorkflowsEventConverter.ToInternal(@event),

            _ => null
        };

        return result;
    }
}
