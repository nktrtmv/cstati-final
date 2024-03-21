using System.Runtime.CompilerServices;

namespace Cstati.Events.Workflows.GenericSubdomain.Exceptions;

public sealed class UnsupportedTypeArgumentException<TExpectedType> : ArgumentException
{
    public UnsupportedTypeArgumentException(
        object actualValue,
        [CallerArgumentExpression("actualValue")]
        string? paramName = null)
        : base(
            paramName,
            $"Argument should be of (type: {typeof(TExpectedType)}) but has (type: {actualValue.GetType().FullName}).")
    {
    }
}
