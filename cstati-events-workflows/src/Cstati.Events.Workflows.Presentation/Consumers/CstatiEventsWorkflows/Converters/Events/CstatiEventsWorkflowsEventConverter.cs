using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.Complete;
using Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.GuestPaymentRefundRequested;
using Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.Start;

using MediatR;

namespace Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events;

internal static class CstatiEventsWorkflowsEventConverter
{
    internal static IRequest? ToInternal(CstatiEventsWorkflowsEventValue value)
    {
        IRequest? result = value.EventCase switch
        {
            CstatiEventsWorkflowsEventValue.EventOneofCase.Start =>
                StartCstatiEventsWorkflowsEventConverter.ToInternal(value),

            CstatiEventsWorkflowsEventValue.EventOneofCase.GuestPaymentRefundRequested =>
                GuestPaymentRefundRequestedCstatiEventsWorkflowsEventConverter.ToInternal(value),

            CstatiEventsWorkflowsEventValue.EventOneofCase.Complete =>
                CompleteCstatiEventsWorkflowsEventConverter.ToInternal(value),

            _ => null
        };

        return result;
    }
}
