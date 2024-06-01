using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.Domain.Entities.Events;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts.Events;

internal static class GetCstatiEventsQueryResponseEventInternalConverter
{
    internal static GetCstatiEventsQueryResponseEventInternal FromDomain(CstatiEvent @event)
    {
        CstatiEventStatusInternal status = CstatiEventStatusInternalConverter.FromDomain(@event.State.Status);

        var result = new GetCstatiEventsQueryResponseEventInternal(
            @event.Id,
            @event.Info.Name,
            @event.Info.ExcelSheetLink,
            status,
            @event.Info.Date,
            @event.Info.Location,
            @event.Info.ExpectedGuestsCount,
            @event.ConcurrencyToken);

        return result;
    }
}
