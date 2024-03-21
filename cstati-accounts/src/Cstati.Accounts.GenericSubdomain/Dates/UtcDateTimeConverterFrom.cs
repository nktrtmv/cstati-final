using Google.Protobuf.WellKnownTypes;

namespace Cstati.Accounts.GenericSubdomain.Dates;

public static class UtcDateTimeConverterFrom
{
    public static UtcDateTime FromUtcDateTime(DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("DateTime kind should be in UTC time format.", nameof(dateTime));
        }

        var result = new UtcDateTime(dateTime);

        return result;
    }

    public static UtcDateTime FromTicks(long ticks)
    {
        var dateTime = new DateTime(ticks, DateTimeKind.Utc);

        var result = new UtcDateTime(dateTime);

        return result;
    }

    public static UtcDateTime FromUtcDateTimeWithMicrosecondsPrecision(DateTime dateTime)
    {
        const long ticksPerMicrosecond = TimeSpan.TicksPerMillisecond / 1000;

        long dateTimeTicksWithMicrosecondsPrecision = dateTime.Ticks - dateTime.Ticks % ticksPerMicrosecond;

        var dateTimeWithMicrosecondsPrecision = new DateTime(dateTimeTicksWithMicrosecondsPrecision);

        DateTime dateTimeWithMicrosecondsPrecisionWithKind =
            DateTime.SpecifyKind(dateTimeWithMicrosecondsPrecision, dateTime.Kind);

        UtcDateTime result = FromUtcDateTime(dateTimeWithMicrosecondsPrecisionWithKind);

        return result;
    }

    public static UtcDateTime FromUnspecifiedUtcDateTime(DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Unspecified)
        {
            throw new ArgumentException("DateTime kind should be Unspecified.", nameof(dateTime));
        }

        DateTime value = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

        var result = new UtcDateTime(value);

        return result;
    }

    public static UtcDateTime FromTimestamp(Timestamp dateTime)
    {
        var value = dateTime.ToDateTime();

        UtcDateTime result = FromUtcDateTime(value);

        return result;
    }
}
