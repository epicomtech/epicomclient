using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAsyncEnumerable
{
    /// <summary>
    /// Provides a set of static methods for working with objects that implement <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    public static class AsyncEnumerable
    {
        /// <summary>
        /// Creates an async enumerable that will be lazy populated by provided producer.
        /// </summary>
        /// <typeparam name="T">The type of objects to enumerate.</typeparam>
        /// <param name="producer">The producer function that will be invoked in order to populate the async enumerable.</param>
        /// <returns>An instance of an asynchronous enumerable.</returns>
        public static IAsyncEnumerable<T> Create<T>(Func<IYielder<T>, CancellationToken, Task> producer)
        {
            var enumerator = new YieldableAsyncEnumerator<T>(producer);
            return new AnonymousAsyncEnumerable<T>(enumerator);
        }

        /// <summary>
        /// Returns an empty IAsyncEnumerable that has the specified type argument.
        /// </summary>
        /// <typeparam name="T">The type to assign to the type parameter of the returned generic <see cref="IAsyncEnumerable{T}"/>.</typeparam>
        /// <returns>An empty <see cref="IAsyncEnumerable{T}"/></returns>
        public static IAsyncEnumerable<T> Empty<T>()
        {
            return Create<T>((yielder, cancellationToken) =>
            {
                yielder.Break();
                return Task.WhenAll();
            });
        }

        /// <summary>
        /// Iterates over an async enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Enumerable to be iterated over.</param>
        /// <param name="action">Action to be synchronously called at every iteration.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public static async Task ForEachAsync<T>(this IAsyncEnumerable<T> source, Action<T> action)
        {
            var enumerator = source.GetEnumerator();
            while (await enumerator.MoveNextAsync(CancellationToken.None))
            {
                action(enumerator.Current);
            }
        }

        /// <summary>
        /// Iterates over an async enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Enumerable to be iterated over.</param>
        /// <param name="action">Action to be called asynchronously at every iteration.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        public static async Task ForEachAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task> action)
        {
            var enumerator = source.GetEnumerator();
            while (await enumerator.MoveNextAsync(CancellationToken.None))
            {
                await action(enumerator.Current);
            }
        }

        /// <summary>
        /// Iterates over an async enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Enumerable to be iterated over.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="action"></param>
        /// <returns>A <see cref="Task"/>.</returns>
        public static async Task ForEachAsync<T>(this IAsyncEnumerable<T> source, CancellationToken cancellationToken,
            Func<T, CancellationToken, Task> action)
        {
            var enumerator = source.GetEnumerator();
            while (await enumerator.MoveNextAsync(cancellationToken))
            {
                await action(enumerator.Current, cancellationToken);
            }
        }

        /// <summary>
        /// Creates a <see cref="List{T}"/> from an <see cref="IAsyncEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IAsyncEnumerable{T}"/> to create a <see cref="List{T}"/> from.</param>
        /// <returns>A <see cref="List{T}"/> that contains elements from the input sequence.</returns>
        public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> source)
        {
            var list = new List<T>();
            await source.ForEachAsync(arg => list.Add(arg));
            return list;
        }

        /// <summary>
        /// Creates a <see cref="IEnumerable{T}"/> from an <see cref="IAsyncEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IAsyncEnumerable{T}"/> to create a <see cref="IEnumerable{T}"/> from.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> that contains elements from the input sequence.</returns>
        public static async Task<IEnumerable<T>> ToEnumerableAsync<T>(this IAsyncEnumerable<T> source)
        {
            return await source.ToListAsync();
        }

        class AnonymousAsyncEnumerable<T> : IAsyncEnumerable<T>
        {
            private readonly IAsyncEnumerator<T> enumerator;

            public AnonymousAsyncEnumerable(IAsyncEnumerator<T> enumerator)
            {
                this.enumerator = enumerator;
            }

            public IAsyncEnumerator<T> GetEnumerator()
            {
                return enumerator;
            }
        }
    }
}