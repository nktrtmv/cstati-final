using Cstati.Events.Application.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.DeleteExpense;

[UsedImplicitly]
internal sealed class DeleteExpenseCstatiEventsFinancesCommandInternalHandler : IRequestHandler<DeleteExpenseCstatiEventsFinancesCommandInternal>
{
    public DeleteExpenseCstatiEventsFinancesCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task Handle(DeleteExpenseCstatiEventsFinancesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        @event.State.FinancesDetails.DeleteExpense(request.ExpenseId);

        await Events.Upsert(@event, cancellationToken);
    }
}
