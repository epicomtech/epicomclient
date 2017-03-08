using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAsyncEnumerable
{
    /// <summary>
    /// Supports an asynchronous iteration over a generic collection.
    /// </summary>
    /// <typeparam name="T">The type of the objects to enumerate.</typeparam>
    public interface IAsyncEnumerator<out T> : IDisposable
    {
        /// <summary>
        /// Asynchronously advances the enumerator to the next element of the collection.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
        /// <returns>
        /// true if the enumerator was successfully advanced to the next element; 
        /// false if the enumerator has passed the end of the collection.
        /// </returns>
        Task<bool> MoveNextAsync(CancellationToken cancellationToken);
        
        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        T Current { get; }
    }
}