using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.Domain.Entities.Events;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts.Events;

internal static class GetAllCstatiEventsQueryResponseEventInternalConverter
{
    internal static GetAllCstatiEventsQueryResponseEventInternal FromDomain(CstatiEvent @event)
    {
        CstatiEventStatusInternal status = CstatiEventStatusInternalConverter.FromDomain(@event.Status);

        var result = new GetAllCstatiEventsQueryResponseEventInternal(@event.Id, @event.Info.Name, status);

        return result;
    }
}
