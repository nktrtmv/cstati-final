using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;

public sealed class CstatiEventFinancesDetails
{
    internal CstatiEventFinancesDetails(double collected, double currentBalance, CstatiEventExpense[] expenses, double revenue)
    {
        Collected = collected;
        CurrentBalance = currentBalance;
        Expenses = expenses;
        Revenue = revenue;
    }

    public double Collected { get; }
    public double CurrentBalance { get; }
    public CstatiEventExpense[] Expenses { get; }
    public double Revenue { get; }
}
