namespace Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Merges <paramref name="left"/> with <paramref name="enumerable"/> and returns the merged entries <typeparamref name="T"/> as flattened <see cref="HashSet{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static HashSet<T> MergeAndFlatten<T>(this IEnumerable<T> left, params IEnumerable<T>[] enumerable)
        => EnumerableExtensions.MergeAndFlatten(enumerable: [left, .. enumerable]);

    /// <summary>
    /// Merges <paramref name="enumerable"/> and returns the merged entries <typeparamref name="T"/> as flattened <see cref="HashSet{T}"/>.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    private static HashSet<T> MergeAndFlatten<T>(params IEnumerable<T>[] enumerable)
        => enumerable.Aggregate((enum1, enum2) => enum1.Concat(enum2)).ToHashSet();
}
