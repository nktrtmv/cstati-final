using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.Info;

public sealed partial class CstatiEventInfo
{
    private CstatiEventInfo(string name, string? excelSheetLink, UtcDateTime? date, string? location, int? expectedGuestsCount)
    {
        Name = name;
        ExcelSheetLink = excelSheetLink;
        Date = date;
        Location = location;
        ExpectedGuestsCount = expectedGuestsCount;
    }

    public static CstatiEventInfo CreateNew(string name)
    {
        string? excelSheetLink = null;

        UtcDateTime? date = null;

        string? location = null;

        int? guestsCount = null;

        var result = new CstatiEventInfo(name, excelSheetLink, date, location, guestsCount);

        return result;
    }

    public static CstatiEventInfo CreateFrom(string name, string? excelSheetLink, UtcDateTime? date, string? location, int? expectedGuestsCount)
    {
        var result = new CstatiEventInfo(name, excelSheetLink, date, location, expectedGuestsCount);

        return result;
    }
}
