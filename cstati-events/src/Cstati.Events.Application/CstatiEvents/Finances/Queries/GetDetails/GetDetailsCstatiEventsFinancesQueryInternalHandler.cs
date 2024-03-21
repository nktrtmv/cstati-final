using Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts;
using Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails;

[UsedImplicitly]
internal sealed class GetDetailsCstatiEventsFinancesQueryInternalHandler
    : IRequestHandler<GetDetailsCstatiEventsFinancesQueryInternal, GetDetailsCstatiEventsFinancesQueryResponseInternal>
{
    public GetDetailsCstatiEventsFinancesQueryInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task<GetDetailsCstatiEventsFinancesQueryResponseInternal> Handle(
        GetDetailsCstatiEventsFinancesQueryInternal request,
        CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        CstatiEventExpense[] expenses = @event.State.FinancesDetails.Expenses
            .Take(request.ExpensesLimit)
            .ToArray();

        GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal[] expensesInternal =
            expenses.Select(GetDetailsCstatiEventsFinancesQueryResponseExpenseInternalConverter.FromDomain).ToArray();

        var result = new GetDetailsCstatiEventsFinancesQueryResponseInternal(
            @event.State.FinancesDetails.Collected,
            @event.State.FinancesDetails.CurrentBalance,
            expensesInternal,
            @event.State.FinancesDetails.Revenue,
            @event.ConcurrencyToken);

        return result;
    }
}
