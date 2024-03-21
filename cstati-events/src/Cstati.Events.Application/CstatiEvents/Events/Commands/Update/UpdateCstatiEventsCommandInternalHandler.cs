using Cstati.Events.Application.CstatiEvents.Events.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateCstatiEventsCommandInternalHandler : IRequestHandler<UpdateCstatiEventsCommandInternal>
{
    public UpdateCstatiEventsCommandInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

    public async Task Handle(UpdateCstatiEventsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventStatus status = CstatiEventStatusInternalConverter.ToDomain(request.Status);

        CstatiEventUpdatingContext updatingContext = CstatiEventUpdatingContextFactory.CreateWithUpdatedInfo(
            @event,
            request.ExcelSheetLink,
            request.Date,
            request.Location,
            request.ExpectedGuestsCount,
            status);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
