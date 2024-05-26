namespace Cstati.Events.Application.Services.Processors.ApplicationEvents;

internal interface IApplicationEventProcessor
{
    Type Type { get; }

    Task Process(string eventId, Guid applicationEventId, CancellationToken cancellationToken);
}
