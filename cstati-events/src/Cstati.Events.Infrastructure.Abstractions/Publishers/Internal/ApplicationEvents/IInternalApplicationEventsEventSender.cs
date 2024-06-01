namespace Cstati.Events.Infrastructure.Abstractions.Publishers.Internal.ApplicationEvents;

public interface IInternalApplicationEventsEventSender
{
    Task SendProcessCommand(string eventId, CancellationToken cancellationToken);
}
