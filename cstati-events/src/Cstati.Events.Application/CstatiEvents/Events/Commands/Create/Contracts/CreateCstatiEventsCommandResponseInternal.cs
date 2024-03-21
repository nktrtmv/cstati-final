namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Create.Contracts;

public sealed class CreateCstatiEventsCommandResponseInternal
{
    internal CreateCstatiEventsCommandResponseInternal(string eventId)
    {
        EventId = eventId;
    }

    public string EventId { get; }
}
