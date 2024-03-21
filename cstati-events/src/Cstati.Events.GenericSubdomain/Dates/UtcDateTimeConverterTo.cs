using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.GenericSubdomain.Dates;

public static class UtcDateTimeConverterTo
{
    public static DateTime ToDateTime(UtcDateTime utcDateTime)
    {
        DateTime result = utcDateTime.Value;

        return result;
    }

    public static Timestamp ToTimestamp(UtcDateTime utcDateTime)
    {
        Timestamp result = Timestamp.FromDateTime(DateTime.SpecifyKind(utcDateTime.Value, DateTimeKind.Utc));

        return result;
    }

    public static long ToTicks(UtcDateTime utcDateTime)
    {
        long ticks = utcDateTime.Value.Ticks;

        return ticks;
    }
}
