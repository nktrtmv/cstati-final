using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Delete.Contracts;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteCstatiEventsTasksCommandInternalHandler : IRequestHandler<DeleteCstatiEventsTasksCommandInternal>
{
    public DeleteCstatiEventsTasksCommandInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

    public async Task Handle(DeleteCstatiEventsTasksCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventUpdatingContext updatingContext = CstatiEventUpdatingContextFactory.CreateWithoutTask(@event, request.TaskId);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
