namespace Cstati.Events.Domain.ValueObjects.ApplicationEvents;

public abstract class CstatiEventApplicationEvent
{
    protected CstatiEventApplicationEvent(string eventId)
    {
        EventId = eventId;
    }

    public string EventId { get; }
}
