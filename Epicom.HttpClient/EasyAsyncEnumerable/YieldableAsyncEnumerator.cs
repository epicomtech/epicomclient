using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAsyncEnumerable
{
    sealed class YieldableAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly Func<IYielder<T>, CancellationToken, Task> producer;
        private readonly BufferedYielder<T> yielder;

        public YieldableAsyncEnumerator(Func<IYielder<T>, CancellationToken, Task> producer)
        {
            this.producer = producer;
            yielder = new BufferedYielder<T>();
        }

        public async Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return false;
            if (yielder.State == YielderState.Idle) await producer(yielder, cancellationToken);
            if (yielder.State == YielderState.Idle || yielder.State == YielderState.Stopped) return false;
            
            Current = yielder.GetNext();
            return true;
        }

        public void Dispose()
        {
        }

        public T Current { get; private set; }
    }
}