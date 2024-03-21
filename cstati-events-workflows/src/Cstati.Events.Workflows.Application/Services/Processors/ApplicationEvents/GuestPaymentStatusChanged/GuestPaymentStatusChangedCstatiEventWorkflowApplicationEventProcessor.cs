using Cstati.Events.Workflows.Domain.ValueObjects.ApplicationEvents.GuestPaymentStatusChanged;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;

namespace Cstati.Events.Workflows.Application.Services.Processors.ApplicationEvents.GuestPaymentStatusChanged;

internal sealed class GuestPaymentStatusChangedCstatiEventWorkflowApplicationEventProcessor : IApplicationEventProcessor
{
    public GuestPaymentStatusChangedCstatiEventWorkflowApplicationEventProcessor(ICstatiEventsWorkflowsEventsSender workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsEventsSender Workflows { get; }

    public async Task Process<TApplicationEvent>(TApplicationEvent applicationEvent, CancellationToken cancellationToken)
    {
        if (applicationEvent is not GuestPaymentStatusChangedCstatiEventWorkflowApplicationEvent guestPaymentStatusChanged)
        {
            return;
        }

        await Workflows.SendGuestPaymentStatusChangedEvent(
            guestPaymentStatusChanged.EventId,
            guestPaymentStatusChanged.GuestTelegramLogin,
            guestPaymentStatusChanged.GuestPaymentStatus,
            guestPaymentStatusChanged.TicketPrice,
            cancellationToken);
    }
}
