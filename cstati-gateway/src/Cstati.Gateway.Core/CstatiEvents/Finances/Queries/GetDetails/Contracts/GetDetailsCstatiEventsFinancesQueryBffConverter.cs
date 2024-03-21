using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts;

internal static class GetDetailsCstatiEventsFinancesQueryBffConverter
{
    internal static GetDetailsCstatiEventsFinancesQuery ToDto(GetDetailsCstatiEventsFinancesQueryBff query, int expensesLimit)
    {
        var result = new GetDetailsCstatiEventsFinancesQuery
        {
            EventId = query.EventId,
            ExpensesLimit = expensesLimit
        };

        return result;
    }
}
