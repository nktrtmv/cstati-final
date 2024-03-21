using Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Complete.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Completers;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.CstatiEventsWorkflows.Events.Complete;

[UsedImplicitly]
internal sealed class CompleteCstatiEventsWorkflowsEventInternalHandler : IRequestHandler<CompleteCstatiEventsWorkflowsEventInternal>
{
    public CompleteCstatiEventsWorkflowsEventInternalHandler(ICstatiEventsWorkflowsRepository workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }

    public async Task Handle(CompleteCstatiEventsWorkflowsEventInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        CstatiEventWorkflowCompleter.Complete(workflow);

        await Workflows.Upsert(workflow, cancellationToken);
    }
}
