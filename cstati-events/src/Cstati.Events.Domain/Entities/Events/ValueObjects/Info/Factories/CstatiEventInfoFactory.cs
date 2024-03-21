using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.Info.Factories;

internal static class CstatiEventInfoFactory
{
    internal static CstatiEventInfo CreateNew(string name)
    {
        string? excelSheetLink = null;

        UtcDateTime? date = null;

        string? location = null;

        int? guestsCount = null;

        var result = new CstatiEventInfo(name, excelSheetLink, date, location, guestsCount);

        return result;
    }

    internal static CstatiEventInfo CreateFrom(string name, string? excelSheetLink, UtcDateTime? date, string? location, int? expectedGuestsCount)
    {
        var result = new CstatiEventInfo(name, excelSheetLink, date, location, expectedGuestsCount);

        return result;
    }
}
