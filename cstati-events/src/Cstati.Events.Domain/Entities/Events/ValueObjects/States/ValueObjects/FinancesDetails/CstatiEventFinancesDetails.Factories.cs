using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;

public sealed partial class CstatiEventFinancesDetails
{
    private CstatiEventFinancesDetails(double collected, double currentBalance, CstatiEventExpense[] expenses, double revenue)
    {
        Collected = collected;
        CurrentBalance = currentBalance;
        Expenses = expenses;
        Revenue = revenue;
    }

    internal static CstatiEventFinancesDetails CreateNew()
    {
        const double collected = 0;

        const double currentBalance = 0;

        CstatiEventExpense[] expenses = [];

        const double revenue = 0;

        var result = new CstatiEventFinancesDetails(collected, currentBalance, expenses, revenue);

        return result;
    }

    public static CstatiEventFinancesDetails CreateFrom(double collected, double currentBalance, CstatiEventExpense[] expenses, double revenue)
    {
        var result = new CstatiEventFinancesDetails(collected, currentBalance, expenses, revenue);

        return result;
    }
}
