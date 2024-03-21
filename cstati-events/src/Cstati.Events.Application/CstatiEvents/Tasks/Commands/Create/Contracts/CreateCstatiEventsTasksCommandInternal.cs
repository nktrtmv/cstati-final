using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Create.Contracts;

public sealed class CreateCstatiEventsTasksCommandInternal : IRequest
{
    public CreateCstatiEventsTasksCommandInternal(
        string eventId,
        string name,
        string executorLogin,
        string description,
        UtcDateTime? deadline,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        Name = name;
        ExecutorLogin = executorLogin;
        Description = description;
        Deadline = deadline;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string Name { get; }
    internal string ExecutorLogin { get; }
    internal string Description { get; }
    internal UtcDateTime? Deadline { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
