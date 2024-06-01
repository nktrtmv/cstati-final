using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.ValueObjects.Statuses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;

public abstract class ApplicationEvent
{
    protected ApplicationEvent(Guid id, ApplicationEventStatus status, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; }
    public ApplicationEventStatus Status { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }

    public void Complete()
    {
        Status = ApplicationEventStatus.Completed;

        UpdatedAt = DateTime.UtcNow;
    }
}
