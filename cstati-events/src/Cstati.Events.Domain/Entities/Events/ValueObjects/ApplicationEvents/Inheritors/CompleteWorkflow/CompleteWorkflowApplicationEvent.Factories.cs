using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.ValueObjects.Statuses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.Inheritors.CompleteWorkflow;

public sealed partial class CompleteWorkflowApplicationEvent
{
    private CompleteWorkflowApplicationEvent(Guid id, ApplicationEventStatus status, DateTime createdAt, DateTime updatedAt) : base(id, status, createdAt, updatedAt)
    {
    }

    public static CompleteWorkflowApplicationEvent CreateNew()
    {
        var id = Guid.NewGuid();

        const ApplicationEventStatus status = ApplicationEventStatus.InProcess;

        DateTime createdAt = DateTime.UtcNow;

        return new CompleteWorkflowApplicationEvent(id, status, createdAt, createdAt);
    }

    public static CompleteWorkflowApplicationEvent CreateFrom(Guid id, ApplicationEventStatus status, DateTime createdAt, DateTime updatedAt)
    {
        return new CompleteWorkflowApplicationEvent(id, status, createdAt, updatedAt);
    }
}
