using Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Events.Converters.Queries.Get.Events;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Queries.Get;

internal static class GetCstatiEventsQueryResponseConverter
{
    internal static GetCstatiEventsQueryResponse FromInternal(GetCstatiEventsQueryResponseInternal response)
    {
        GetCstatiEventsQueryResponseEvent @event = GetCstatiEventsQueryResponseEventConverter.FromInternal(response.Event);

        var result = new GetCstatiEventsQueryResponse
        {
            Event = @event
        };

        return result;
    }
}
