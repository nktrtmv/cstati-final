using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Exceptions;

namespace Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;

internal static class CstatiEventStatusInternalConverter
{
    internal static CstatiEventStatusInternal FromDomain(CstatiEventStatus status)
    {
        CstatiEventStatusInternal result = status switch
        {
            CstatiEventStatus.NotStarted => CstatiEventStatusInternal.NotStarted,
            CstatiEventStatus.InProgress => CstatiEventStatusInternal.InProgress,
            CstatiEventStatus.Finished => CstatiEventStatusInternal.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventStatus ToDomain(CstatiEventStatusInternal status)
    {
        CstatiEventStatus result = status switch
        {
            CstatiEventStatusInternal.NotStarted => CstatiEventStatus.NotStarted,
            CstatiEventStatusInternal.InProgress => CstatiEventStatus.InProgress,
            CstatiEventStatusInternal.Finished => CstatiEventStatus.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
