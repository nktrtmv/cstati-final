using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Delete.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteCstatiEventsTasksCommandInternalHandler : IRequestHandler<DeleteCstatiEventsTasksCommandInternal>
{
    public DeleteCstatiEventsTasksCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(DeleteCstatiEventsTasksCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        @event.State.DeleteTask(request.TaskId);

        await Events.Upsert(@event, cancellationToken);
    }
}
