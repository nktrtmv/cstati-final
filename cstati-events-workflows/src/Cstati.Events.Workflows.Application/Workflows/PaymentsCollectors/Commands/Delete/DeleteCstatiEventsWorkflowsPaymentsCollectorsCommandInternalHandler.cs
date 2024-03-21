using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Delete.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternalHandler : IRequestHandler<DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternal>
{
    public DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowUpdatingContext context =
            CstatiEventWorkflowUpdatingContextFactory.CreateWithoutPaymentCollector(workflow, request.PersonLogin);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
