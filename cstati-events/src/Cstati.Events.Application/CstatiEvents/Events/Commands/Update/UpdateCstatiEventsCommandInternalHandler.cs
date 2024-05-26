using Cstati.Events.Application.CstatiEvents.Events.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.ValueObjects.Events.Updates;
using Cstati.Events.Infrastructure.Abstractions.Publishers.Internal.ApplicationEvents;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateCstatiEventsCommandInternalHandler : IRequestHandler<UpdateCstatiEventsCommandInternal>
{
    public UpdateCstatiEventsCommandInternalHandler(ICstatiEventsRepository events, IInternalApplicationEventsEventSender sender)
    {
        Events = events;
        Sender = sender;
    }

    private ICstatiEventsRepository Events { get; }
    private IInternalApplicationEventsEventSender Sender { get; }

    public async Task Handle(UpdateCstatiEventsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventStatus status = CstatiEventStatusInternalConverter.ToDomain(request.Status);

        var update = new CstatiEventUpdate
        {
            ExcelSheetLink = request.ExcelSheetLink,
            Date = request.Date,
            Location = request.Location,
            ExpectedGuestsCount = request.ExpectedGuestsCount,
            Status = status
        };

        @event.Update(update);

        await Events.Upsert(@event, cancellationToken);

        await Sender.SendProcessCommand(@event.Id, cancellationToken);
    }
}
