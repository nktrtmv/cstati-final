using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories.ValueObjects.Context;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add;

[UsedImplicitly]
internal sealed class AddCstatiEventsWorkflowsGuestsCommandInternalHandler : IRequestHandler<AddCstatiEventsWorkflowsGuestsCommandInternal>
{
    public AddCstatiEventsWorkflowsGuestsCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(AddCstatiEventsWorkflowsGuestsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowGuestCreationContext[] guestsCreationContexts =
            request.Guests.Select(AddCstatiEventsWorkflowsGuestsCommandGuestInternalConverter.ToDomain).ToArray();

        CstatiEventWorkflowGuest[] guests = guestsCreationContexts.Select(CstatiEventWorkflowGuestFactory.CreateNew).ToArray();

        CstatiEventWorkflowUpdatingContext context = CstatiEventWorkflowUpdatingContextFactory.CreateWithNewGuests(workflow, guests);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
