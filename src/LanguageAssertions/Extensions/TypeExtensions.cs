namespace LanguageAssertions.Extensions;

/// <summary>
/// Extension methods for <see cref="Type"/>.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Checks if a type implements an interface.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> to test.</param>
    /// <param name="interface">The interface to check if <paramref name="type"/> implements.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="type"/> implements <paramref name="interface"/>;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// If <paramref name="interface"/> is an unbounded generic, then the interfaces
    /// compared against will be converted to their unbounded generic equivalent.
    /// </para>
    /// <para>
    /// If <paramref name="interface"/> is a constructed generic, then the interfaces
    /// compared against will be compared exactly as there are implemented as.
    /// </para>
    /// </remarks>
    public static bool IsInterface(this Type type, Type @interface)
    {
        if (@interface.IsGenericTypeDefinition)
        {
            return type
                .GetInterfaces()
                .Where(t => t.IsGenericType)
                .Select(t => t.GetGenericTypeDefinition())
                .Any(t => t == @interface);
        }

        if (@interface.IsConstructedGenericType)
        {
            return type
                .GetInterfaces()
                .Where(t => t.IsGenericType)
                .Any(t => t == @interface);
        }

        return type
            .GetInterfaces()
            .Where(t => !t.IsGenericType)
            .Any(t => t == @interface);
    }

    /// <summary>
    /// Checks if a type implements <see cref="IDictionary{TKey,TValue}"/>.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> to test.</param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="type"/> implements <see cref="IDictionary{TKey,TValue}"/>;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public static bool IsDictionary(this Type type)
    {
        if (type.IsGenericType)
        {
            var unboundedType = type.GetGenericTypeDefinition();

            if (unboundedType == typeof(IDictionary<,>))
                return true;
        }

        return type.IsInterface(typeof(IDictionary<,>));
    }
}
