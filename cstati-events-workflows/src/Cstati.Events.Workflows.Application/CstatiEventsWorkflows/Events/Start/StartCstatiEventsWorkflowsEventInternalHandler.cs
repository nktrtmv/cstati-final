using Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Start.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Factories;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Start;

[UsedImplicitly]
internal sealed class StartCstatiEventsWorkflowsEventInternalHandler : IRequestHandler<StartCstatiEventsWorkflowsEventInternal>
{
    public StartCstatiEventsWorkflowsEventInternalHandler(ICstatiEventsWorkflowsRepository workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }

    public async Task Handle(StartCstatiEventsWorkflowsEventInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = CstatiEventWorkflowFactory.CreateNew(request.EventId);

        await Workflows.Upsert(workflow, cancellationToken);
    }
}
