using System.Globalization;

using Cstati.Events.Workflows.GenericSubdomain.Dates;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

public static class ConcurrencyTokenConverterFrom
{
    public static ConcurrencyToken FromString(string concurrencyToken)
    {
        DateTime dateTime = DateTime.ParseExact(concurrencyToken, ConcurrencyToken.OutputStringFormat, null, DateTimeStyles.RoundtripKind);

        UtcDateTime value = UtcDateTimeConverterFrom.FromUtcDateTime(dateTime);

        var result = new ConcurrencyToken(value);

        return result;
    }

    public static ConcurrencyToken FromUtcDateTime(DateTime dateTime)
    {
        UtcDateTime value = UtcDateTimeConverterFrom.FromUtcDateTime(dateTime);

        var result = new ConcurrencyToken(value);

        return result;
    }

    public static ConcurrencyToken FromUnspecifiedUtcDateTime(DateTime concurrencyToken)
    {
        UtcDateTime value = UtcDateTimeConverterFrom.FromUnspecifiedUtcDateTime(concurrencyToken);

        var result = new ConcurrencyToken(value);

        return result;
    }
}
