using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Exceptions;
using Cstati.Events.Infrastructure.Repositories.Contracts;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Statuses;

internal static class CstatiEventStatusDbConverter
{
    internal static CstatiEventStatusDb FromDomain(CstatiEventStatus status)
    {
        CstatiEventStatusDb result = status switch
        {
            CstatiEventStatus.NotStarted => CstatiEventStatusDb.NotStarted,
            CstatiEventStatus.InProgress => CstatiEventStatusDb.InProgress,
            CstatiEventStatus.Finished => CstatiEventStatusDb.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventStatus ToDomain(CstatiEventStatusDb status)
    {
        CstatiEventStatus result = status switch
        {
            CstatiEventStatusDb.NotStarted => CstatiEventStatus.NotStarted,
            CstatiEventStatusDb.InProgress => CstatiEventStatus.InProgress,
            CstatiEventStatusDb.Finished => CstatiEventStatus.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static string ToString(CstatiEventStatus status)
    {
        string result = status switch
        {
            CstatiEventStatus.NotStarted => "NotStarted",
            CstatiEventStatus.InProgress => "InProgress",
            CstatiEventStatus.Finished => "Finished",
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
