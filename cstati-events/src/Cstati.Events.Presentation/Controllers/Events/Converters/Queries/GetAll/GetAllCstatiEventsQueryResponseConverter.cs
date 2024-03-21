using Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Events.Converters.Queries.GetAll.Events;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Queries.GetAll;

internal static class GetAllCstatiEventsQueryResponseConverter
{
    internal static GetAllCstatiEventsQueryResponse FromInternal(GetAllCstatiEventsQueryResponseInternal response)
    {
        GetAllCstatiEventsQueryResponseEvent[] events =
            response.Events.Select(GetAllCstatiEventsQueryResponseEventConverter.FromInternal).ToArray();

        var result = new GetAllCstatiEventsQueryResponse
        {
            Events = { events }
        };

        return result;
    }
}
