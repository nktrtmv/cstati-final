using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Workflows.GenericSubdomain.Dates;

public static class UtcDateTimeConverterTo
{
    public static DateTime ToDateTime(UtcDateTime utcDateTime)
    {
        DateTime result = utcDateTime.Value;

        return result;
    }

    public static Timestamp ToTimeStamp(UtcDateTime utcDateTime)
    {
        Timestamp result = Timestamp.FromDateTime(DateTime.SpecifyKind(utcDateTime.Value, DateTimeKind.Utc));

        return result;
    }

    public static long ToTicks(UtcDateTime utcDateTime)
    {
        long ticks = utcDateTime.Value.Ticks;

        return ticks;
    }

    public static string ToString(UtcDateTime utcDateTime)
    {
        var result = utcDateTime.Value.ToString("f");

        return result;
    }
}
