using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;

public sealed partial class CstatiEventFinancesDetails
{
    public void UpdateCollected(double collected)
    {
        Collected = collected;
    }

    public void ActualizeRevenue()
    {
        Revenue = CurrentBalance;
    }

    public void AddExpense(string personLogin, string description, double amount, string market)
    {
        var expense = CstatiEventExpense.CreateNew(personLogin, description, amount, market);

        Expenses = Expenses.Append(expense).ToArray();
    }

    public void DeleteExpense(string expenseId)
    {
        Expenses = Expenses.Where(e => e.Id != expenseId).ToArray();
    }
}
