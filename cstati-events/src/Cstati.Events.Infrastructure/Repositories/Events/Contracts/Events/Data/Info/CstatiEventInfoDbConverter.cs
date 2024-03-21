using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.GenericSubdomain;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.Infrastructure.Repositories.Contracts;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.Info;

internal static class CstatiEventInfoDbConverter
{
    internal static CstatiEventInfoDb FromDomain(CstatiEventInfo info)
    {
        Timestamp? date = NullableConverter.Convert(info.Date, UtcDateTimeConverterTo.ToTimestamp);

        var result = new CstatiEventInfoDb
        {
            Name = info.Name,
            ExcelSheetLink = info.ExcelSheetLink,
            Date = date,
            Location = info.Location,
            ExpectedGuestsCount = info.ExpectedGuestsCount
        };

        return result;
    }

    internal static CstatiEventInfo ToDomain(CstatiEventInfoDb info)
    {
        UtcDateTime? date = NullableConverter.Convert(info.Date, UtcDateTimeConverterFrom.FromTimestamp);

        var result = new CstatiEventInfo(info.Name, info.ExcelSheetLink, date, info.Location, info.ExpectedGuestsCount);

        return result;
    }
}
