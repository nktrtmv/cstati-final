using Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Finances.Converters.Queries.GetDetails.Expenses;

internal static class GetDetailsCstatiEventsFinancesQueryResponseExpenseConverter
{
    internal static GetDetailsCstatiEventsFinancesQueryResponseExpense FromInternal(GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal expense)
    {
        var result = new GetDetailsCstatiEventsFinancesQueryResponseExpense
        {
            Id = expense.Id,
            PersonLogin = expense.PersonLogin,
            Description = expense.Description,
            Amount = expense.Amount,
            Market = expense.Market
        };

        return result;
    }
}
