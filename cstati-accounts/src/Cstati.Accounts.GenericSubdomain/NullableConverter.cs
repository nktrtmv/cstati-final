using JetBrains.Annotations;

namespace Cstati.Accounts.GenericSubdomain;

public static class NullableConverter
{
    public static T? Convert<T, TSource>(TSource? source, Func<TSource, T> converter, RequireClass<T>? _ = null)
        where TSource : class
        where T : class
    {
        if (source is null)
        {
            return null;
        }

        T result = converter(source);

        return result;
    }

    public static T[]? Convert<T, TSource>(IEnumerable<TSource>? source, Func<TSource, T> converter, RequireClass<T>? _ = null)
        where TSource : class
        where T : class
    {
        if (source is null)
        {
            return null;
        }

        T[] result = source.Select(converter).ToArray();

        return result;
    }

    public static T? Convert<T, TSource>(TSource? source, Func<TSource, T> converter, RequireStruct<T>? _ = null)
        where TSource : class
        where T : struct
    {
        if (source is null)
        {
            return null;
        }

        T result = converter(source);

        return result;
    }

    public static T? Convert<T, TSource>(TSource? source, Func<TSource, T> converter, RequireClass<T>? _ = null)
        where TSource : struct
        where T : class
    {
        if (source is null)
        {
            return null;
        }

        T result = converter(source.Value);

        return result;
    }

    public static T? Convert<T, TSource>(TSource? source, Func<TSource, T> converter, RequireStruct<T>? _ = null)
        where TSource : struct
        where T : struct
    {
        if (source is null)
        {
            return null;
        }

        T result = converter(source.Value);

        return result;
    }

    [UsedImplicitly]

    // ReSharper disable once UnusedTypeParameter
    public sealed class RequireStruct<T> where T : struct
    {
    }

    [UsedImplicitly]

    // ReSharper disable once UnusedTypeParameter
    public sealed class RequireClass<T> where T : class
    {
    }
}
