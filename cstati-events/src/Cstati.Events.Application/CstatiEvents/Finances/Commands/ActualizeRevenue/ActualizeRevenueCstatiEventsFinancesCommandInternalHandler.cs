using Cstati.Events.Application.CstatiEvents.Events.Commands.Delete.Contracts;
using Cstati.Events.Application.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.ActualizeRevenue;

[UsedImplicitly]
internal sealed class ActualizeRevenueCstatiEventsFinancesCommandInternalHandler : IRequestHandler<ActualizeRevenueCstatiEventsFinancesCommandInternal>
{
    public ActualizeRevenueCstatiEventsFinancesCommandInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

    public async Task Handle(ActualizeRevenueCstatiEventsFinancesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventUpdatingContext updatingContext = CstatiEventUpdatingContextFactory.CreateWithActualizedRevenue(@event);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
