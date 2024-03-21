using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.GenericSubdomain.Exceptions;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Contracts.Statuses;

internal static class CstatiEventStatusDtoConverter
{
    internal static CstatiEventStatusInternal ToInternal(CstatiEventStatusDto status)
    {
        CstatiEventStatusInternal result = status switch
        {
            CstatiEventStatusDto.NotStarted => CstatiEventStatusInternal.NotStarted,
            CstatiEventStatusDto.InProgress => CstatiEventStatusInternal.InProgress,
            CstatiEventStatusDto.Finished => CstatiEventStatusInternal.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventStatusDto FromInternal(CstatiEventStatusInternal status)
    {
        CstatiEventStatusDto result = status switch
        {
            CstatiEventStatusInternal.NotStarted => CstatiEventStatusDto.NotStarted,
            CstatiEventStatusInternal.InProgress => CstatiEventStatusDto.InProgress,
            CstatiEventStatusInternal.Finished => CstatiEventStatusDto.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
