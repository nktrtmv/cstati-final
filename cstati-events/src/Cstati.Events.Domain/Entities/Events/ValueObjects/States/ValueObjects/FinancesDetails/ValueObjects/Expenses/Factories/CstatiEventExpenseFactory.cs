namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses.Factories;

public static class CstatiEventExpenseFactory
{
    public static CstatiEventExpense CreateNew(string personLogin, string description, double amount, string market)
    {
        var id = Guid.NewGuid().ToString();

        var result = new CstatiEventExpense(id, personLogin, description, amount, market);

        return result;
    }
}
