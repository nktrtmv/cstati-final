using Cstati.Accounts.GenericSubdomain.Dates;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

public static class ConcurrencyTokenConverterTo
{
    public static string ToString(ConcurrencyToken concurrencyToken)
    {
        var result = concurrencyToken.Value.Value.ToString(ConcurrencyToken.OutputStringFormat);

        return result;
    }

    public static DateTime ToDateTime(ConcurrencyToken concurrencyToken)
    {
        var result = UtcDateTimeConverterTo.ToDateTime(concurrencyToken.Value);

        return result;
    }

    public static Timestamp ToTimestamp(ConcurrencyToken concurrencyToken)
    {
        Timestamp result = UtcDateTimeConverterTo.ToTimeStamp(concurrencyToken.Value);

        return result;
    }
}
