using System.Runtime.CompilerServices;
using MongoDB.Driver;

namespace Herond.Common.Utils
{
    /// <summary>
    /// Asynchronous enumeration of documents.
    /// </summary>
    public static class AsyncEnumerable
    {
        /// <summary>
        /// Provides asynchronous iteration over all document returned by cursor returned by a <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TDocument">The type of the documents to be iterated.</typeparam>
        /// <param name="source">The cursor source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Async-enumerable that iterates over all document returned by cursor returned by cursor source.
        public static async IAsyncEnumerable<TDocument> ToAsyncEnumerable<TDocument>(
            this IAsyncCursorSource<TDocument> source,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var cursor = await source.ToCursorAsync(cancellationToken).ConfigureAwait(false);

            await foreach (var document in cursor.ToAsyncEnumerable(cancellationToken))
            {
                yield return document;
            }
        }

        /// <summary>
        /// Provides asynchronous iteration over all document returned by <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TDocument">The type of the documents to be iterated.</typeparam>
        /// <param name="source">The source cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Async-enumerable that iterates over all document returned by cursor.</returns>
        public static async IAsyncEnumerable<TDocument> ToAsyncEnumerable<TDocument>(
            this IAsyncCursor<TDocument> source,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            while (await source.MoveNextAsync(cancellationToken).ConfigureAwait(false))
            {
                foreach (var document in source.Current)
                {
                    yield return document;
                }
            }
        }
    }

}