using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Update.Contracts;

public sealed class UpdateCstatiEventsTasksCommandInternal : IRequest
{
    public UpdateCstatiEventsTasksCommandInternal(
        string eventId,
        string taskId,
        string name,
        string executorLogin,
        string description,
        UtcDateTime? deadline,
        CstatiEventTaskStatusInternal status,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        TaskId = taskId;
        Name = name;
        ExecutorLogin = executorLogin;
        Description = description;
        Deadline = deadline;
        Status = status;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string TaskId { get; }
    internal string Name { get; }
    internal string ExecutorLogin { get; }
    internal string Description { get; }
    internal UtcDateTime? Deadline { get; }
    internal CstatiEventTaskStatusInternal Status { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
