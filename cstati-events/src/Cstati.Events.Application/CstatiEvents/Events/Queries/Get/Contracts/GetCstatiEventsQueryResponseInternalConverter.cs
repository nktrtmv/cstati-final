using Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts.Events;
using Cstati.Events.Domain.Entities.Events;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts;

internal static class GetCstatiEventsQueryResponseInternalConverter
{
    internal static GetCstatiEventsQueryResponseInternal FromDomain(CstatiEvent response)
    {
        GetCstatiEventsQueryResponseEventInternal @event = GetCstatiEventsQueryResponseEventInternalConverter.FromDomain(response);

        var result = new GetCstatiEventsQueryResponseInternal(@event);

        return result;
    }
}
