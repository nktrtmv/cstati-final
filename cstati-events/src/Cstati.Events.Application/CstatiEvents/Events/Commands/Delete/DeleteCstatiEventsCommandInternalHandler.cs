using Cstati.Events.Application.CstatiEvents.Events.Commands.Delete.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteCstatiEventsCommandInternalHandler : IRequestHandler<DeleteCstatiEventsCommandInternal>
{
    public DeleteCstatiEventsCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(DeleteCstatiEventsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        if (@event.Status != CstatiEventStatus.NotStarted)
        {
            throw new ApplicationException($"Cannot delete started event (eventId: {request.EventId}).");
        }

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        await Events.Delete(request.EventId, request.ConcurrencyToken, cancellationToken);
    }
}
