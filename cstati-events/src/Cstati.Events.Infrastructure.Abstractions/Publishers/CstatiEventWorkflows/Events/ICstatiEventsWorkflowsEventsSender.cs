namespace Cstati.Events.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;

public interface ICstatiEventsWorkflowsEventsSender
{
    Task SendStartRequest(string eventId, string eventName, CancellationToken cancellationToken);
    Task SendCompleteRequest(string eventId, CancellationToken cancellationToken);
}
