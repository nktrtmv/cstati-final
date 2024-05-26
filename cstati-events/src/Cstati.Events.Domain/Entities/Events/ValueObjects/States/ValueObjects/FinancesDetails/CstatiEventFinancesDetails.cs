using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;

public sealed partial class CstatiEventFinancesDetails
{
    public double Collected { get; private set; }
    public double CurrentBalance { get; }
    public CstatiEventExpense[] Expenses { get; private set; }
    public double Revenue { get; private set; }
}
