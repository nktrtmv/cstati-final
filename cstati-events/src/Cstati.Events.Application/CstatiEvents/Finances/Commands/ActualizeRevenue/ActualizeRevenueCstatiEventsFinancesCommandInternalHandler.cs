using Cstati.Events.Application.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.ActualizeRevenue;

[UsedImplicitly]
internal sealed class ActualizeRevenueCstatiEventsFinancesCommandInternalHandler : IRequestHandler<ActualizeRevenueCstatiEventsFinancesCommandInternal>
{
    public ActualizeRevenueCstatiEventsFinancesCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(ActualizeRevenueCstatiEventsFinancesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        @event.State.FinancesDetails.ActualizeRevenue();

        await Events.Upsert(@event, cancellationToken);
    }
}
