using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.ValueObjects.Statuses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.Inheritors.StartWorkflow;

public sealed partial class StartWorkflowApplicationEvent
{
    private StartWorkflowApplicationEvent(Guid id, ApplicationEventStatus status, DateTime createdAt, DateTime updatedAt) : base(id, status, createdAt, updatedAt)
    {
    }

    public static StartWorkflowApplicationEvent CreateNew()
    {
        var id = Guid.NewGuid();

        const ApplicationEventStatus status = ApplicationEventStatus.InProcess;

        DateTime createdAt = DateTime.UtcNow;

        return new StartWorkflowApplicationEvent(id, status, createdAt, createdAt);
    }

    public static StartWorkflowApplicationEvent CreateFrom(Guid id, ApplicationEventStatus status, DateTime createdAt, DateTime updatedAt)
    {
        return new StartWorkflowApplicationEvent(id, status, createdAt, updatedAt);
    }
}
