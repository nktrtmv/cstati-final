using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts;
using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts.GuestsPaymentsStatuses;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.GenericSubdomain.Exceptions;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged;

[UsedImplicitly]
internal sealed class GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternalHandler : IRequestHandler<GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternal>
{
    public GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

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

        CstatiEventUpdatingContext updatingContext =
            CstatiEventUpdatingContextFactory.CreateWithUpdatedCollected(@event, collected);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
