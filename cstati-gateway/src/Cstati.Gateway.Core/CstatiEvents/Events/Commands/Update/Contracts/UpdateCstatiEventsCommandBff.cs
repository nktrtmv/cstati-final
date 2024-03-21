using Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Update.Contracts;

public sealed class UpdateCstatiEventsCommandBff
{
    public required string EventId { get; init; }
    public required string? ExcelSheetLink { get; init; }
    public required CstatiEventStatusBff Status { get; init; }
    public required DateTime? Date { get; init; }
    public required string? Location { get; init; }
    public required int? ExpectedGuestsCount { get; init; }
    public required string ConcurrencyToken { get; init; }
}
