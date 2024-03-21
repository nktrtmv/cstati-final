using Cstati.Events.Application.CstatiEvents.Events.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.GenericSubdomain;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Events.Converters.Contracts.Statuses;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Commands.Update;

internal static class UpdateCstatiEventsCommandConverter
{
    internal static UpdateCstatiEventsCommandInternal ToInternal(UpdateCstatiEventsCommand command)
    {
        CstatiEventStatusInternal status = CstatiEventStatusDtoConverter.ToInternal(command.Status);

        UtcDateTime? date = NullableConverter.Convert(command.Date, UtcDateTimeConverterFrom.FromTimestamp);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new UpdateCstatiEventsCommandInternal(
            command.EventId,
            command.ExcelSheetLink,
            status,
            date,
            command.Location,
            command.ExpectedGuestsCount,
            concurrencyToken);

        return result;
    }
}
