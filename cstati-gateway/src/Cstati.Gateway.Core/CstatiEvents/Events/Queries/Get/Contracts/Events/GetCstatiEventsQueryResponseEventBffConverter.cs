using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts.Events;

internal static class GetCstatiEventsQueryResponseEventBffConverter
{
    internal static GetCstatiEventsQueryResponseEventBff FromDto(GetCstatiEventsQueryResponseEvent @event)
    {
        CstatiEventStatusBff status = CstatiEventStatusBffConverter.FromDto(@event.Status);

        var date = @event.Date?.ToDateTime();

        var result = new GetCstatiEventsQueryResponseEventBff
        {
            Id = @event.Id,
            Name = @event.Name,
            ExcelSheetLink = @event.ExcelSheetLink,
            Status = status,
            Date = date,
            Location = @event.Location,
            ExpectedGuestsCount = @event.ExpectedGuestsCount,
            ConcurrencyToken = @event.ConcurrencyToken
        };

        return result;
    }
}
