namespace Cstati.Events.GenericSubdomain.Exceptions;

public sealed class OptimisticConcurrencyException : Exception
{
    public OptimisticConcurrencyException() : base("Optimistic concurrency exception")
    {
    }
}
