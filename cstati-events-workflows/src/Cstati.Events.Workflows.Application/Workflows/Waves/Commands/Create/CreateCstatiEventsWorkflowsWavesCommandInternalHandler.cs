using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Create.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Create;

[UsedImplicitly]
internal sealed class CreateCstatiEventsWorkflowsWavesCommandInternalHandler : IRequestHandler<CreateCstatiEventsWorkflowsWavesCommandInternal>
{
    public CreateCstatiEventsWorkflowsWavesCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(CreateCstatiEventsWorkflowsWavesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowUpdatingContext context = CstatiEventWorkflowUpdatingContextFactory.CreateWithNewWave(workflow);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
