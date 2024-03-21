namespace Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;

public sealed class GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal
{
    internal GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal(string id, string personLogin, string description, double amount, string market)
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
