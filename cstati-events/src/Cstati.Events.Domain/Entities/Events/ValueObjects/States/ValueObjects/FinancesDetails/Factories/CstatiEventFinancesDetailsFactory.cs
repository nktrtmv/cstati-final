using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.Factories;

public static class CstatiEventFinancesDetailsFactory
{
    internal static CstatiEventFinancesDetails CreateNew()
    {
        const double collected = 0;

        const double currentBalance = 0;

        CstatiEventExpense[] expenses = Array.Empty<CstatiEventExpense>();

        const double revenue = 0;

        var result = new CstatiEventFinancesDetails(collected, currentBalance, expenses, revenue);

        return result;
    }

    public static CstatiEventFinancesDetails CreateFromDb(double collected, double currentBalance, CstatiEventExpense[] expenses, double revenue)
    {
        var result = new CstatiEventFinancesDetails(collected, currentBalance, expenses, revenue);

        return result;
    }

    internal static CstatiEventFinancesDetails CreateWithNewExpense(CstatiEventFinancesDetails financesDetails, CstatiEventExpense expense)
    {
        double currentBalance = financesDetails.CurrentBalance - expense.Amount;

        CstatiEventExpense[] expenses = financesDetails.Expenses.Append(expense).ToArray();

        var result = new CstatiEventFinancesDetails(
            financesDetails.Collected,
            currentBalance,
            expenses,
            financesDetails.Revenue);

        return result;
    }

    internal static CstatiEventFinancesDetails CreateWithoutExpense(CstatiEventFinancesDetails financesDetails, string expenseId)
    {
        CstatiEventExpense expense = financesDetails.Expenses.Single(e => e.Id == expenseId);

        double currentBalance = financesDetails.CurrentBalance + expense.Amount;

        CstatiEventExpense[] expenses = financesDetails.Expenses.Where(e => e.Id != expense.Id).ToArray();

        var result = new CstatiEventFinancesDetails(
            financesDetails.Collected,
            currentBalance,
            expenses,
            financesDetails.Revenue);

        return result;
    }

    public static CstatiEventFinancesDetails CreateWithUpdatedCollected(CstatiEventFinancesDetails financesDetails, double collected)
    {
        double spentAmount = financesDetails.Expenses.Sum(e => e.Amount);

        double currentBalance = collected - spentAmount;

        var result = new CstatiEventFinancesDetails(
            collected,
            currentBalance,
            financesDetails.Expenses,
            financesDetails.Revenue);

        return result;
    }

    public static CstatiEventFinancesDetails CreateWithActualizedRevenue(CstatiEventFinancesDetails financesDetails)
    {
        var result = new CstatiEventFinancesDetails(
            financesDetails.Collected,
            financesDetails.CurrentBalance,
            financesDetails.Expenses,
            financesDetails.CurrentBalance);

        return result;
    }
}
