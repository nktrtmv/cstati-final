using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts;
using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts.GuestsPaymentsStatuses;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.GenericSubdomain.Exceptions;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged;

[UsedImplicitly]
internal sealed class GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternalHandler : IRequestHandler<GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternal>
{
    public GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        double collected = @event.State.FinancesDetails.Collected +
            request.PaymentStatus switch
            {
                CstatiEventWorkflowGuestPaymentStatusInternal.Paid => request.TicketPrice,
                CstatiEventWorkflowGuestPaymentStatusInternal.Refunded => -request.TicketPrice,
                _ => throw new ArgumentTypeOutOfRangeException(request.PaymentStatus)
            };

        @event.State.FinancesDetails.UpdateCollected(collected);

        await Events.Upsert(@event, cancellationToken);
    }
}
