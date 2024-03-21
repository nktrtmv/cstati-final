using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Contracts.Tasks.Statuses;

internal static class CstatiEventTaskStatusBffConverter
{
    internal static CstatiEventTaskStatusDto ToDto(CstatiEventTaskStatusBff status)
    {
        CstatiEventTaskStatusDto result = status switch
        {
            CstatiEventTaskStatusBff.NotStarted => CstatiEventTaskStatusDto.NotStarted,
            CstatiEventTaskStatusBff.InProgress => CstatiEventTaskStatusDto.InProgress,
            CstatiEventTaskStatusBff.Completed => CstatiEventTaskStatusDto.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventTaskStatusBff FromDto(CstatiEventTaskStatusDto status)
    {
        CstatiEventTaskStatusBff result = status switch
        {
            CstatiEventTaskStatusDto.NotStarted => CstatiEventTaskStatusBff.NotStarted,
            CstatiEventTaskStatusDto.InProgress => CstatiEventTaskStatusBff.InProgress,
            CstatiEventTaskStatusDto.Completed => CstatiEventTaskStatusBff.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
