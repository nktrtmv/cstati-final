using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;
using Cstati.Events.Infrastructure.Repositories.Contracts;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.FinancesDetails.Expenses;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.FinancesDetails;

internal static class CstatiEventFinancesDetailsDbConverter
{
    internal static CstatiEventFinancesDetailsDb FromDomain(CstatiEventFinancesDetails financesDetails)
    {
        CstatiEventExpenseDb[] expenses = financesDetails.Expenses.Select(CstatiEventExpenseDbConverter.FromDomain).ToArray();

        var result = new CstatiEventFinancesDetailsDb
        {
            Collected = financesDetails.Collected,
            CurrentBalance = financesDetails.CurrentBalance,
            Expenses = { expenses },
            Revenue = financesDetails.Revenue
        };

        return result;
    }

    internal static CstatiEventFinancesDetails ToDomain(CstatiEventFinancesDetailsDb financesDetails)
    {
        CstatiEventExpense[] expenses = financesDetails.Expenses.Select(CstatiEventExpenseDbConverter.ToDomain).ToArray();

        CstatiEventFinancesDetails result = CstatiEventFinancesDetailsFactory.CreateFromDb(
            financesDetails.Collected,
            financesDetails.CurrentBalance,
            expenses,
            financesDetails.Revenue);

        return result;
    }
}
