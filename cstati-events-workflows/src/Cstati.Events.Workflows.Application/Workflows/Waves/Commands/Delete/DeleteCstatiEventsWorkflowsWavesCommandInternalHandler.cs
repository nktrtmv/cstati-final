using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Delete.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteCstatiEventsWorkflowsWavesCommandInternalHandler : IRequestHandler<DeleteCstatiEventsWorkflowsWavesCommandInternal>
{
    public DeleteCstatiEventsWorkflowsWavesCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(DeleteCstatiEventsWorkflowsWavesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowWave wave = workflow.Waves.Single(w => w.Ordinal == request.Ordinal);

        if (wave.StartedAt is not null || wave.Guests.Any())
        {
            throw new ApplicationException("Cannot delete started wave or wave with guests");
        }

        CstatiEventWorkflowUpdatingContext context =
            CstatiEventWorkflowUpdatingContextFactory.CreateWithoutWave(workflow, request.Ordinal);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
