using Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Finances.Converters.Queries.GetDetails;

internal static class GetDetailsCstatiEventsFinancesQueryConverter
{
    internal static GetDetailsCstatiEventsFinancesQueryInternal ToInternal(GetDetailsCstatiEventsFinancesQuery query)
    {
        var result = new GetDetailsCstatiEventsFinancesQueryInternal(query.EventId, query.ExpensesLimit);

        return result;
    }
}
