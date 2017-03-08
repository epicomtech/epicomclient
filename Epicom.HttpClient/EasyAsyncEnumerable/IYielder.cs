namespace EasyAsyncEnumerable
{
    /// <summary>
    /// Yields values from an async enumerator.
    /// </summary>
    /// <typeparam name="T">Type of the values to be yieled.</typeparam>
    public interface IYielder<in T>
    {
        /// <summary>
        /// Enqueues a value to be processed by the iterator.
        /// </summary>
        /// <param name="value">Value to be enqueued.</param>
        /// <returns>An instance of the <see cref="BufferedYielder{T}"/> class so further calls can be chained.</returns>
        void Return(T value);

        /// <summary>
        /// Ends the iteration.
        /// </summary>
        void Break();
    }
}