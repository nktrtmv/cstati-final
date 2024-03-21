using Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts.Events;
using Cstati.Events.GenericSubdomain;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Events.Converters.Contracts.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Queries.Get.Events;

internal static class GetCstatiEventsQueryResponseEventConverter
{
    internal static GetCstatiEventsQueryResponseEvent FromInternal(GetCstatiEventsQueryResponseEventInternal @event)
    {
        CstatiEventStatusDto status = CstatiEventStatusDtoConverter.FromInternal(@event.Status);

        Timestamp? date = NullableConverter.Convert(@event.Date, UtcDateTimeConverterTo.ToTimestamp);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(@event.ConcurrencyToken);

        var result = new GetCstatiEventsQueryResponseEvent
        {
            Id = @event.Id,
            Name = @event.Name,
            ExcelSheetLink = @event.ExcelSheetLink,
            Status = status,
            Date = date,
            Location = @event.Location,
            ExpectedGuestsCount = @event.ExpectedGuestsCount,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
