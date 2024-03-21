using System.Globalization;

using Cstati.Accounts.GenericSubdomain.Dates;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

public static class ConcurrencyTokenConverterFrom
{
    public static ConcurrencyToken FromString(string concurrencyToken)
    {
        DateTime dateTime = DateTime.ParseExact(concurrencyToken, ConcurrencyToken.OutputStringFormat, null, DateTimeStyles.RoundtripKind);

        UtcDateTime value = UtcDateTimeConverterFrom.FromUtcDateTime(dateTime);

        var result = new ConcurrencyToken(value);

        return result;
    }

    public static ConcurrencyToken FromTimestamp(Timestamp timestamp)
    {
        UtcDateTime value = UtcDateTimeConverterFrom.FromTimestamp(timestamp);

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
