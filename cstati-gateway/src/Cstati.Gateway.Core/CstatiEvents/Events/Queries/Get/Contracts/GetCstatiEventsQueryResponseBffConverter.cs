using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts.Events;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts;

internal static class GetCstatiEventsQueryResponseBffConverter
{
    internal static GetCstatiEventsQueryResponseBff FromDto(GetCstatiEventsQueryResponse response)
    {
        GetCstatiEventsQueryResponseEventBff @event = GetCstatiEventsQueryResponseEventBffConverter.FromDto(response.Event);

        var result = new GetCstatiEventsQueryResponseBff
        {
            Event = @event
        };

        return result;
    }
}
