using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Exceptions;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;

internal static class CstatiEventTaskStatusInternalConverter
{
    internal static CstatiEventTaskStatusInternal FromDomain(CstatiEventTaskStatus status)
    {
        CstatiEventTaskStatusInternal result = status switch
        {
            CstatiEventTaskStatus.NotStarted => CstatiEventTaskStatusInternal.NotStarted,
            CstatiEventTaskStatus.InProgress => CstatiEventTaskStatusInternal.InProgress,
            CstatiEventTaskStatus.Completed => CstatiEventTaskStatusInternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventTaskStatus ToDomain(CstatiEventTaskStatusInternal status)
    {
        CstatiEventTaskStatus result = status switch
        {
            CstatiEventTaskStatusInternal.NotStarted => CstatiEventTaskStatus.NotStarted,
            CstatiEventTaskStatusInternal.InProgress => CstatiEventTaskStatus.InProgress,
            CstatiEventTaskStatusInternal.Completed => CstatiEventTaskStatus.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
