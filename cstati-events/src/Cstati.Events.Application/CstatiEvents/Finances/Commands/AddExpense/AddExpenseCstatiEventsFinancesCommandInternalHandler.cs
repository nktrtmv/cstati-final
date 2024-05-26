using Cstati.Events.Application.CstatiEvents.Finances.Commands.AddExpense.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.AddExpense;

[UsedImplicitly]
internal sealed class AddExpenseCstatiEventsFinancesCommandInternalHandler : IRequestHandler<AddExpenseCstatiEventsFinancesCommandInternal>
{
    public AddExpenseCstatiEventsFinancesCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(AddExpenseCstatiEventsFinancesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        @event.State.FinancesDetails.AddExpense(request.PersonLogin, request.Description, request.Amount, request.Market);

        await Events.Upsert(@event, cancellationToken);
    }
}
