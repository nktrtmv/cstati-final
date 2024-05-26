using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.ValueObjects.Events.Updates;

public sealed class CstatiEventUpdate
{
    public required string? ExcelSheetLink { get; init; }
    public required UtcDateTime? Date { get; init; }
    public required string? Location { get; init; }
    public required int? ExpectedGuestsCount { get; init; }
    public required CstatiEventStatus Status { get; init; }
}
