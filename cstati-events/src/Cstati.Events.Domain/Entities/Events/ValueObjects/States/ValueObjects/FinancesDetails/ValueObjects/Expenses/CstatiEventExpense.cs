namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

public sealed class CstatiEventExpense
{
    public CstatiEventExpense(string id, string personLogin, string description, double amount, string market)
    {
        Id = id;
        PersonLogin = personLogin;
        Description = description;
        Amount = amount;
        Market = market;
    }

    public string Id { get; }
    public string PersonLogin { get; }
    public string Description { get; }
    public double Amount { get; }
    public string Market { get; }
}
