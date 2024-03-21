using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;

namespace Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

public interface ICstatiEventsWorkflowsRepository
{
    Task Upsert(CstatiEventWorkflow workflow, CancellationToken cancellationToken);
    Task<CstatiEventWorkflow> GetRequired(string eventId, CancellationToken cancellationToken);
}
