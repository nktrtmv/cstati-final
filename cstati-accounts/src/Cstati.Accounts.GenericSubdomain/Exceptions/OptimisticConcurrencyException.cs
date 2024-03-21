namespace Cstati.Accounts.GenericSubdomain.Exceptions;

public sealed class OptimisticConcurrencyException : Exception
{
    public OptimisticConcurrencyException() : base("Optimistic concurrency exception")
    {
    }
}
