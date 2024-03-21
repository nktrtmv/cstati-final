using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Complete.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Complete;

[UsedImplicitly]
internal sealed class CompleteCstatiEventsWorkflowsWavesCommandInternalHandler : IRequestHandler<CompleteCstatiEventsWorkflowsWavesCommandInternal>
{
    public CompleteCstatiEventsWorkflowsWavesCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(CompleteCstatiEventsWorkflowsWavesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowUpdatingContext context =
            CstatiEventWorkflowUpdatingContextFactory.CreateWithCompletedWave(workflow, request.Ordinal);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
