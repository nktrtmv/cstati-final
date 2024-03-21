using MediatR;

namespace Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.GuestPaymentRefundRequested.Contracts;

public sealed class GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternal : IRequest
{
    public GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternal(string eventId, string guestTelegramLogin)
    {
        EventId = eventId;
        GuestTelegramLogin = guestTelegramLogin;
    }

    internal string EventId { get; }
    internal string GuestTelegramLogin { get; }
}
