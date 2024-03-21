using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsTasksCommandInternal : IRequest
{
    public DeleteCstatiEventsTasksCommandInternal(string eventId, string taskId, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        TaskId = taskId;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string TaskId { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
