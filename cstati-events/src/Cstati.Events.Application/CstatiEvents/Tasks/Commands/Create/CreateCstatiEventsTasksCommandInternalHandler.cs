using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Create.Contracts;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Create;

[UsedImplicitly]
internal sealed class CreateCstatiEventsCommandInternalHandler : IRequestHandler<CreateCstatiEventsTasksCommandInternal>
{
    public CreateCstatiEventsCommandInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

    public async Task Handle(CreateCstatiEventsTasksCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventTask task = CstatiEventTaskFactory.CreateNew(request.Name, request.ExecutorLogin, request.Description, request.Deadline);

        CstatiEventUpdatingContext updatingContext = CstatiEventUpdatingContextFactory.CreateWithNewTask(@event, task);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
