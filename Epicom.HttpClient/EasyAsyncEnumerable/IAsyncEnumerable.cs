namespace EasyAsyncEnumerable
{
    /// <summary>
    /// Exposes an async enumerator, which supports a simple asynchronous iteration over a collection of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate.</typeparam>
    public interface IAsyncEnumerable<out T>
    {
        /// <summary>
        /// Returns an async enumerator that asynchronously iterates through the collection.
        /// </summary>
        /// <returns>An IAsyncEnumerator(T) that can be used to asynchronously iterate over the collection.</returns>
        IAsyncEnumerator<T> GetEnumerator();
    }
}
