using Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.GuestPaymentRefundRequested.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.GuestPaymentRefundRequested;

internal static class GuestPaymentRefundRequestedCstatiEventsWorkflowsEventConverter
{
    internal static GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternal ToInternal(CstatiEventsWorkflowsEventValue value)
    {
        var result = new GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternal(
            value.EventId,
            value.GuestPaymentRefundRequested.GuestTelegramLogin);

        return result;
    }
}
