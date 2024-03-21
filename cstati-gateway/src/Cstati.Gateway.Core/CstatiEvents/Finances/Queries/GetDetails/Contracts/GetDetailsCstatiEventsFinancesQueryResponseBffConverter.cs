using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts;

internal static class GetDetailsCstatiEventsFinancesQueryResponseBffConverter
{
    internal static GetDetailsCstatiEventsFinancesQueryResponseBff FromDto(GetDetailsCstatiEventsFinancesQueryResponse response, EnrichersContext enrichers)
    {
        GetDetailsCstatiEventsFinancesQueryResponseExpenseBff[] expenses =
            response.Expenses.Select(e => GetDetailsCstatiEventsFinancesQueryResponseExpenseBffConverter.FromDto(e, enrichers)).ToArray();

        var result = new GetDetailsCstatiEventsFinancesQueryResponseBff
        {
            Collected = response.Collected,
            CurrentBalance = response.CurrentBalance,
            Expenses = expenses,
            Revenue = response.Revenue,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
