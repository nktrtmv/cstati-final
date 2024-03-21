using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateCstatiEventsTasksCommandInternalHandler : IRequestHandler<UpdateCstatiEventsTasksCommandInternal>
{
    public UpdateCstatiEventsTasksCommandInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

    public async Task Handle(UpdateCstatiEventsTasksCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventTaskStatus status = CstatiEventTaskStatusInternalConverter.ToDomain(request.Status);

        CstatiEventTask task = CstatiEventTaskFactory.CreateFrom(request.TaskId, request.Name, request.ExecutorLogin, request.Description, request.Deadline, status);

        CstatiEventUpdatingContext updatingContext = CstatiEventUpdatingContextFactory.CreateWithUpdatedTask(@event, task);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
