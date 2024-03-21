using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Gateway.GenericSubdomain.Services.Converters;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Update.Contracts;

internal static class UpdateCstatiEventsCommandBffConverter
{
    internal static UpdateCstatiEventsCommand ToDto(UpdateCstatiEventsCommandBff command)
    {
        CstatiEventStatusDto status = CstatiEventStatusBffConverter.ToDto(command.Status);

        Timestamp? date = NullableConverter.Convert(command.Date, Timestamp.FromDateTime);

        var result = new UpdateCstatiEventsCommand
        {
            EventId = command.EventId,
            ExcelSheetLink = command.ExcelSheetLink,
            Status = status,
            Date = date,
            Location = command.Location,
            ExpectedGuestsCount = command.ExpectedGuestsCount,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
