using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts;

internal static class GetCstatiEventsQueryBffConverter
{
    internal static GetCstatiEventsQuery ToDto(GetCstatiEventsQueryBff query)
    {
        var result = new GetCstatiEventsQuery
        {
            EventId = query.EventId
        };

        return result;
    }
}
