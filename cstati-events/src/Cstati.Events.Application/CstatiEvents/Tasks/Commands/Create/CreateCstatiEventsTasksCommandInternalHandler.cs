using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Create.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Commands.Create;

[UsedImplicitly]
internal sealed class CreateCstatiEventsCommandInternalHandler : IRequestHandler<CreateCstatiEventsTasksCommandInternal>
{
    public CreateCstatiEventsCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(CreateCstatiEventsTasksCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        @event.State.AddTask(request.Name, request.ExecutorLogin, request.Description, request.Deadline);

        await Events.Upsert(@event, cancellationToken);
    }
}
