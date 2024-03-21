namespace Cstati.Events.Application.Services.Processors.ApplicationEvents;

internal interface IApplicationEventProcessor
{
    Task Process<TApplicationEvent>(TApplicationEvent applicationEvent, CancellationToken cancellationToken);
}
