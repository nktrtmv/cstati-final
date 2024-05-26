using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States;

public sealed partial class CstatiEventState
{
    private CstatiEventState(CstatiEventStatus status, CstatiEventTask[] tasks, CstatiEventFinancesDetails financesDetails)
    {
        Status = status;
        Tasks = tasks;
        FinancesDetails = financesDetails;
    }

    public static CstatiEventState CreateNew()
    {
        const CstatiEventStatus status = CstatiEventStatus.NotStarted;

        CstatiEventTask[] tasks = [];

        var financesDetails = CstatiEventFinancesDetails.CreateNew();

        var result = new CstatiEventState(status, tasks, financesDetails);

        return result;
    }

    public static CstatiEventState CreateFrom(CstatiEventStatus status, CstatiEventTask[] tasks, CstatiEventFinancesDetails financesDetails)
    {
        var result = new CstatiEventState(status, tasks, financesDetails);

        return result;
    }
}
