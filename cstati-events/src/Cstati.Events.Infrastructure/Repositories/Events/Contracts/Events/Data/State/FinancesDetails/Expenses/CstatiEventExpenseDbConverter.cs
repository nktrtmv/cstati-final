using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;
using Cstati.Events.Infrastructure.Repositories.Contracts;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.FinancesDetails.Expenses;

internal static class CstatiEventExpenseDbConverter
{
    internal static CstatiEventExpenseDb FromDomain(CstatiEventExpense expense)
    {
        var result = new CstatiEventExpenseDb
        {
            Id = expense.Id,
            PersonLogin = expense.PersonLogin,
            Description = expense.Description,
            Amount = expense.Amount,
            Market = expense.Market
        };

        return result;
    }

    internal static CstatiEventExpense ToDomain(CstatiEventExpenseDb expense)
    {
        var result = new CstatiEventExpense(expense.Id, expense.PersonLogin, expense.Description, expense.Amount, expense.Market);

        return result;
    }
}
