namespace Cstati.Events.GenericSubdomain.Dates;

public readonly record struct UtcDateTime : IComparable<UtcDateTime>
{
    public static readonly UtcDateTime MinValue = new UtcDateTime(DateTime.MinValue);

    internal UtcDateTime(DateTime value)
    {
        Value = value;
    }

    internal DateTime Value { get; }
    public static UtcDateTime Now => UtcDateTimeConverterFrom.FromUtcDateTime(DateTime.UtcNow);

    public static UtcDateTime NowWithMicrosecondsPrecision => UtcDateTimeConverterFrom.FromUtcDateTimeWithMicrosecondsPrecision(DateTime.UtcNow);

    public int CompareTo(UtcDateTime other)
    {
        return Value.CompareTo(other.Value);
    }
}
