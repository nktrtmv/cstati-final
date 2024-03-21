using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

public readonly record struct ConcurrencyToken
{
    internal const string OutputStringFormat = "o";

    public static readonly ConcurrencyToken Empty = new ConcurrencyToken(UtcDateTime.MinValue);

    internal ConcurrencyToken(UtcDateTime value)
    {
        Value = value;
    }

    internal UtcDateTime Value { get; }

    public void AssertEqualsTo(ConcurrencyToken other)
    {
        if (Value != other.Value)
        {
            throw new OptimisticConcurrencyException();
        }
    }
}
