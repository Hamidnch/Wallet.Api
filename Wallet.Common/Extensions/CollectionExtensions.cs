namespace Wallet.Common.Extensions;

public static class CollectionExtensions
{
    public static Task<List<TSource>> ToListAsync<TSource>(this IEnumerable<TSource> source)
    {
        return source.ToAsyncEnumerable().ToListAsync().AsTask();
    }
}