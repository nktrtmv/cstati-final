namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

public sealed partial class CstatiEventExpense
{
    public string Id { get; }
    public string PersonLogin { get; }
    public string Description { get; }
    public double Amount { get; }
    public string Market { get; }
}
