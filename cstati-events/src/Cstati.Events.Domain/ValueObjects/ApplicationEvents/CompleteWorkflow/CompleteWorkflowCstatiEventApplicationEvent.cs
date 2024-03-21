namespace Cstati.Events.Domain.ValueObjects.ApplicationEvents.CompleteWorkflow;

public sealed class CompleteWorkflowCstatiEventApplicationEvent : CstatiEventApplicationEvent
{
    public CompleteWorkflowCstatiEventApplicationEvent(string eventId) : base(eventId)
    {
    }
}
