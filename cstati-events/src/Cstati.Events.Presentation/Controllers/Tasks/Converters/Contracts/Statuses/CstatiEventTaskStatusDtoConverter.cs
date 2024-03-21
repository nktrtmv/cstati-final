using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.GenericSubdomain.Exceptions;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Tasks.Converters.Contracts.Statuses;

internal static class CstatiEventTaskStatusDtoConverter
{
    internal static CstatiEventTaskStatusDto FromInternal(CstatiEventTaskStatusInternal status)
    {
        CstatiEventTaskStatusDto result = status switch
        {
            CstatiEventTaskStatusInternal.NotStarted => CstatiEventTaskStatusDto.NotStarted,
            CstatiEventTaskStatusInternal.InProgress => CstatiEventTaskStatusDto.InProgress,
            CstatiEventTaskStatusInternal.Completed => CstatiEventTaskStatusDto.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventTaskStatusInternal ToInternal(CstatiEventTaskStatusDto status)
    {
        CstatiEventTaskStatusInternal result = status switch
        {
            CstatiEventTaskStatusDto.NotStarted => CstatiEventTaskStatusInternal.NotStarted,
            CstatiEventTaskStatusDto.InProgress => CstatiEventTaskStatusInternal.InProgress,
            CstatiEventTaskStatusDto.Completed => CstatiEventTaskStatusInternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
