namespace Cstati.Events.Domain.ValueObjects.ApplicationEvents.StartWorkflow;

public sealed class StartWorkflowCstatiEventApplicationEvent : CstatiEventApplicationEvent
{
    public StartWorkflowCstatiEventApplicationEvent(string eventId, string eventName) : base(eventId)
    {
        EventName = eventName;
    }

    public string EventName { get; }
}
