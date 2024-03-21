using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.Infrastructure.Repositories.Contracts;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.FinancesDetails;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Statuses;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Tasks;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State;

internal static class CstatiEventStateDbConverter
{
    internal static CstatiEventStateDb FromDomain(CstatiEventState state)
    {
        CstatiEventStatusDb status = CstatiEventStatusDbConverter.FromDomain(state.Status);

        CstatiEventTaskDb[] tasks = state.Tasks.Select(CstatiEventTaskDbConverter.FromDomain).ToArray();

        CstatiEventFinancesDetailsDb financesDetails = CstatiEventFinancesDetailsDbConverter.FromDomain(state.FinancesDetails);

        var result = new CstatiEventStateDb
        {
            Status = status,
            Tasks = { tasks },
            FinancesDetails = financesDetails
        };

        return result;
    }

    internal static CstatiEventState ToDomain(CstatiEventStateDb state)
    {
        CstatiEventStatus status = CstatiEventStatusDbConverter.ToDomain(state.Status);

        CstatiEventTask[] tasks = state.Tasks.Select(CstatiEventTaskDbConverter.ToDomain).ToArray();

        CstatiEventFinancesDetails financesDetails = CstatiEventFinancesDetailsDbConverter.ToDomain(state.FinancesDetails);

        var result = new CstatiEventState(status, tasks, financesDetails);

        return result;
    }
}
