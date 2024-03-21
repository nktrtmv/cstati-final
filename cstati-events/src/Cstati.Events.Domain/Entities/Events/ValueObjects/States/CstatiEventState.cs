using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States;

public sealed class CstatiEventState
{
    public CstatiEventState(CstatiEventStatus status, CstatiEventTask[] tasks, CstatiEventFinancesDetails financesDetails)
    {
        Status = status;
        Tasks = tasks;
        FinancesDetails = financesDetails;
    }

    public CstatiEventStatus Status { get; private set; }
    public CstatiEventTask[] Tasks { get; }
    public CstatiEventFinancesDetails FinancesDetails { get; }
}
