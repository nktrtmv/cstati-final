using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;

internal static class CstatiEventStatusBffConverter
{
    internal static CstatiEventStatusDto ToDto(CstatiEventStatusBff status)
    {
        CstatiEventStatusDto result = status switch
        {
            CstatiEventStatusBff.NotStarted => CstatiEventStatusDto.NotStarted,
            CstatiEventStatusBff.InProgress => CstatiEventStatusDto.InProgress,
            CstatiEventStatusBff.Finished => CstatiEventStatusDto.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventStatusBff FromDto(CstatiEventStatusDto status)
    {
        CstatiEventStatusBff result = status switch
        {
            CstatiEventStatusDto.NotStarted => CstatiEventStatusBff.NotStarted,
            CstatiEventStatusDto.InProgress => CstatiEventStatusBff.InProgress,
            CstatiEventStatusDto.Finished => CstatiEventStatusBff.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
