using Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Finances.Converters.Queries.GetDetails.Expenses;

namespace Cstati.Events.Presentation.Controllers.Finances.Converters.Queries.GetDetails;

internal static class GetDetailsCstatiEventsFinancesQueryResponseConverter
{
    internal static GetDetailsCstatiEventsFinancesQueryResponse FromInternal(GetDetailsCstatiEventsFinancesQueryResponseInternal response)
    {
        GetDetailsCstatiEventsFinancesQueryResponseExpense[] expenses =
            response.Expenses.Select(GetDetailsCstatiEventsFinancesQueryResponseExpenseConverter.FromInternal).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetDetailsCstatiEventsFinancesQueryResponse
        {
            Collected = response.Collected,
            CurrentBalance = response.CurrentBalance,
            Expenses = { expenses },
            Revenue = response.Revenue,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
