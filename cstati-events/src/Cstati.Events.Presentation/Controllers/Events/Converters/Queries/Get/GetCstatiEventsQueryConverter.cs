using Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Queries.Get;

internal static class GetCstatiEventsQueryConverter
{
    internal static GetCstatiEventsQueryInternal ToInternal(GetCstatiEventsQuery query)
    {
        var result = new GetCstatiEventsQueryInternal(query.EventId);

        return result;
    }
}
