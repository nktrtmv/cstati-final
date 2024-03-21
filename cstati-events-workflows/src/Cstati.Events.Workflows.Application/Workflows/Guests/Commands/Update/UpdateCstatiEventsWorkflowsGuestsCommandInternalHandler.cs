using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Update.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateCstatiEventsWorkflowsGuestsCommandInternalHandler : IRequestHandler<UpdateCstatiEventsWorkflowsGuestsCommandInternal>
{
    public UpdateCstatiEventsWorkflowsGuestsCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(UpdateCstatiEventsWorkflowsGuestsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowGuest obsoleteGuest = workflow.Waves.SelectMany(w => w.Guests).Single(g => g.Id == request.GuestId);

        CstatiEventWorkflowGuest guest =
            UpdateCstatiEventsWorkflowsGuestsCommandInternalConverter.ToDomain(request, obsoleteGuest);

        CstatiEventWorkflowUpdatingContext context =
            CstatiEventWorkflowUpdatingContextFactory.CreateWithUpdatedGuest(workflow, guest);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
