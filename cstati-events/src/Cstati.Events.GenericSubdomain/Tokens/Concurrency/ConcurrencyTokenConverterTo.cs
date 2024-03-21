using Cstati.Events.GenericSubdomain.Dates;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.GenericSubdomain.Tokens.Concurrency;

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
        var result = UtcDateTimeConverterTo.ToTimestamp(concurrencyToken.Value);

        return result;
    }
}
