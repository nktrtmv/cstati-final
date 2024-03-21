using Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.GuestPaymentRefundRequested.Contracts;
using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.GuestPaymentRefundRequested;

[UsedImplicitly]
internal sealed class GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternalHandler
    : IRequestHandler<GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternal>
{
    public GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(GuestPaymentRefundRequestedCstatiEventsWorkflowsEventInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        CstatiEventWorkflowGuest obsoleteGuest = workflow.Waves
            .SelectMany(w => w.Guests)
            .Single(g => g.TelegramLogin == request.GuestTelegramLogin);

        CstatiEventWorkflowGuest guest =
            CstatiEventWorkflowGuestFactory.CreateFrom(obsoleteGuest, CstatiEventWorkflowGuestPaymentStatus.RefundRequested);

        CstatiEventWorkflowUpdatingContext context =
            CstatiEventWorkflowUpdatingContextFactory.CreateWithUpdatedGuest(workflow, guest);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
