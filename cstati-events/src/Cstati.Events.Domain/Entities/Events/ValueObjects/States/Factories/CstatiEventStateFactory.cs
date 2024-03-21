using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.Factories;

internal static class CstatiEventStateFactory
{
    internal static CstatiEventState CreateNew()
    {
        const CstatiEventStatus status = CstatiEventStatus.NotStarted;

        CstatiEventTask[] tasks = Array.Empty<CstatiEventTask>();

        CstatiEventFinancesDetails financesDetails = CstatiEventFinancesDetailsFactory.CreateNew();

        var result = new CstatiEventState(status, tasks, financesDetails);

        return result;
    }

    internal static CstatiEventState CreateFrom(CstatiEventStatus status, CstatiEventTask[] tasks, CstatiEventFinancesDetails financesDetails)
    {
        var result = new CstatiEventState(status, tasks, financesDetails);

        return result;
    }
}
