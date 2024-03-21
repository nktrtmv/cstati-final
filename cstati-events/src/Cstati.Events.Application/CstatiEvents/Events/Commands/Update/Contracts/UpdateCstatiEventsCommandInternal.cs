using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Update.Contracts;

public sealed class UpdateCstatiEventsCommandInternal : IRequest
{
    public UpdateCstatiEventsCommandInternal(
        string eventId,
        string? excelSheetLink,
        CstatiEventStatusInternal status,
        UtcDateTime? date,
        string? location,
        int? expectedGuestsCount,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        ExcelSheetLink = excelSheetLink;
        Status = status;
        Date = date;
        Location = location;
        ExpectedGuestsCount = expectedGuestsCount;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string? ExcelSheetLink { get; }
    internal CstatiEventStatusInternal Status { get; }
    internal UtcDateTime? Date { get; }
    internal string? Location { get; }
    internal int? ExpectedGuestsCount { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
