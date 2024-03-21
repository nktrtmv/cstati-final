using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Exceptions;
using Cstati.Events.Infrastructure.Repositories.Contracts;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Tasks.Statuses;

internal static class CstatiEventTaskStatusDbConverter
{
    internal static CstatiEventTaskStatusDb FromDomain(CstatiEventTaskStatus status)
    {
        CstatiEventTaskStatusDb result = status switch
        {
            CstatiEventTaskStatus.NotStarted => CstatiEventTaskStatusDb.NotStarted,
            CstatiEventTaskStatus.InProgress => CstatiEventTaskStatusDb.InProgress,
            CstatiEventTaskStatus.Completed => CstatiEventTaskStatusDb.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventTaskStatus ToDomain(CstatiEventTaskStatusDb status)
    {
        CstatiEventTaskStatus result = status switch
        {
            CstatiEventTaskStatusDb.NotStarted => CstatiEventTaskStatus.NotStarted,
            CstatiEventTaskStatusDb.InProgress => CstatiEventTaskStatus.InProgress,
            CstatiEventTaskStatusDb.Completed => CstatiEventTaskStatus.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
