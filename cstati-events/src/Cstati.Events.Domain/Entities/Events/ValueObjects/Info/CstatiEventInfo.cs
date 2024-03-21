using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.Info;

public sealed class CstatiEventInfo
{
    public CstatiEventInfo(string name, string? excelSheetLink, UtcDateTime? date, string? location, int? expectedGuestsCount)
    {
        Name = name;
        ExcelSheetLink = excelSheetLink;
        Date = date;
        Location = location;
        ExpectedGuestsCount = expectedGuestsCount;
    }

    public string Name { get; }
    public string? ExcelSheetLink { get; }
    public UtcDateTime? Date { get; }
    public string? Location { get; }
    public int? ExpectedGuestsCount { get; }
}
