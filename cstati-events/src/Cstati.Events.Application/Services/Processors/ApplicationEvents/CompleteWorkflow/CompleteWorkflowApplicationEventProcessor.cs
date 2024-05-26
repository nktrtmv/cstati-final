using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.Inheritors.CompleteWorkflow;
using Cstati.Events.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

namespace Cstati.Events.Application.Services.Processors.ApplicationEvents.CompleteWorkflow;

internal sealed class CompleteWorkflowApplicationEventProcessor : ApplicationEventProcessor<CompleteWorkflowApplicationEvent>
{
    public CompleteWorkflowApplicationEventProcessor(
        ICstatiEventsRepository eventsRepository,
        ICstatiEventsWorkflowsEventsSender workflows) : base(eventsRepository)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsEventsSender Workflows { get; }

    protected override async Task Process(CstatiEvent cstatiEvent, CompleteWorkflowApplicationEvent _, CancellationToken cancellationToken)
    {
        await Workflows.SendCompleteRequest(cstatiEvent.Id, cancellationToken);
    }
}
