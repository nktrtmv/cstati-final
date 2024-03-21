using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts.Events;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsQueryResponseBffConverter
{
    internal static GetAllCstatiEventsQueryResponseBff FromDto(GetAllCstatiEventsQueryResponse response)
    {
        GetAllCstatiEventsQueryResponseEventBff[] events =
            response.Events.Select(GetAllCstatiEventsQueryResponseEventBffConverter.FromDto).ToArray();

        var result = new GetAllCstatiEventsQueryResponseBff
        {
            Events = events
        };

        return result;
    }
}
