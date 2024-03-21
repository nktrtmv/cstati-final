using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

namespace Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;

internal static class GetDetailsCstatiEventsFinancesQueryResponseExpenseInternalConverter
{
    internal static GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal FromDomain(CstatiEventExpense expense)
    {
        var result = new GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal(expense.Id, expense.PersonLogin, expense.Description, expense.Amount, expense.Market);

        return result;
    }
}
