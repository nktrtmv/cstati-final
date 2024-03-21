namespace Cstati.Events.Workflows.Domain.ValueObjects.ApplicationEvents;

public abstract class CstatiEventWorkflowApplicationEvent
{
    protected CstatiEventWorkflowApplicationEvent(string eventId)
    {
        EventId = eventId;
    }

    public string EventId { get; }
}
