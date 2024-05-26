using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.Info;

public sealed partial class CstatiEventInfo
{
    public string Name { get; }
    public string? ExcelSheetLink { get; }
    public UtcDateTime? Date { get; }
    public string? Location { get; }
    public int? ExpectedGuestsCount { get; }
}
