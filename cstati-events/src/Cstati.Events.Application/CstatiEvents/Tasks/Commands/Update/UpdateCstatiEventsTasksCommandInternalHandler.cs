using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateCstatiEventsTasksCommandInternalHandler : IRequestHandler<UpdateCstatiEventsTasksCommandInternal>
{
    public UpdateCstatiEventsTasksCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(UpdateCstatiEventsTasksCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventTaskStatus status = CstatiEventTaskStatusInternalConverter.ToDomain(request.Status);

        @event.State.UpdateTask(request.TaskId, request.Name, request.ExecutorLogin, request.Description, request.Deadline, status);

        await Events.Upsert(@event, cancellationToken);
    }
}
