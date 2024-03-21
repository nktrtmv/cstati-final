using Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts.Events;
using Cstati.Events.Domain.Entities.Events;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsQueryResponseInternalConverter
{
    internal static GetAllCstatiEventsQueryResponseInternal FromDomain(CstatiEvent[] response)
    {
        GetAllCstatiEventsQueryResponseEventInternal[] events =
            response.Select(GetAllCstatiEventsQueryResponseEventInternalConverter.FromDomain).ToArray();

        var result = new GetAllCstatiEventsQueryResponseInternal(events);

        return result;
    }
}
