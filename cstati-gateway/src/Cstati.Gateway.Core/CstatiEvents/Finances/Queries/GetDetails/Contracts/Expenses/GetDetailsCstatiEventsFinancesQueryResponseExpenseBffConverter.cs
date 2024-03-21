using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.Common.Persons;
using Cstati.Gateway.Core.Common.Persons.Services.Enrichers.Targets;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;

internal static class GetDetailsCstatiEventsFinancesQueryResponseExpenseBffConverter
{
    internal static GetDetailsCstatiEventsFinancesQueryResponseExpenseBff FromDto(GetDetailsCstatiEventsFinancesQueryResponseExpense expense, EnrichersContext enrichers)
    {
        PersonBff person = PersonsTargetEnricher.Add(enrichers, expense.PersonLogin);

        var result = new GetDetailsCstatiEventsFinancesQueryResponseExpenseBff
        {
            Id = expense.Id,
            Person = person,
            Description = expense.Description,
            Amount = expense.Amount,
            Market = expense.Market
        };

        return result;
    }
}
