using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.Inheritors.StartWorkflow;
using Cstati.Events.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

namespace Cstati.Events.Application.Services.Processors.ApplicationEvents.StartWorkflow;

internal sealed class StartWorkflowApplicationEventProcessor : ApplicationEventProcessor<StartWorkflowApplicationEvent>
{
    public StartWorkflowApplicationEventProcessor(
        ICstatiEventsRepository eventsRepository,
        ICstatiEventsWorkflowsEventsSender workflows) : base(eventsRepository)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsEventsSender Workflows { get; }

    protected override async Task Process(CstatiEvent cstatiEvent, StartWorkflowApplicationEvent _, CancellationToken cancellationToken)
    {
        await Workflows.SendStartRequest(cstatiEvent.Id, cstatiEvent.Info.Name, cancellationToken);
    }
}
