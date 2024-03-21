using System.Runtime.CompilerServices;

namespace Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

public sealed class ArgumentTypeOutOfRangeException : ArgumentOutOfRangeException
{
    public ArgumentTypeOutOfRangeException(object actualValue, [CallerArgumentExpression("actualValue")] string? paramName = null)
        : base(paramName, actualValue, $"Argument (name: {paramName}, type: {actualValue.GetType().FullName}) is not supported.")
    {
    }

    public ArgumentTypeOutOfRangeException(Enum actualValue, [CallerArgumentExpression("actualValue")] string? paramName = null)
        : base(paramName, actualValue, $"Enum argument (name: {paramName}, value ({actualValue}) is not supported.")
    {
    }
}
