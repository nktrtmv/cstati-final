namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

public sealed partial class CstatiEventExpense
{
    private CstatiEventExpense(string id, string personLogin, string description, double amount, string market)
    {
        Id = id;
        PersonLogin = personLogin;
        Description = description;
        Amount = amount;
        Market = market;
    }

    public static CstatiEventExpense CreateNew(string personLogin, string description, double amount, string market)
    {
        var id = Guid.NewGuid().ToString();

        var result = new CstatiEventExpense(id, personLogin, description, amount, market);

        return result;
    }

    public static CstatiEventExpense CreateFrom(string id, string personLogin, string description, double amount, string market)
    {
        var result = new CstatiEventExpense(id, personLogin, description, amount, market);

        return result;
    }
}
