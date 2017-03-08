using System;
using System.Collections.Generic;

namespace EasyAsyncEnumerable
{
    sealed class BufferedYielder<T> : IYielder<T>
    {
        private readonly Queue<T> values;

        public BufferedYielder()
        {
            values = new Queue<T>();
            State = YielderState.Idle;
        }

        public void Return(T value)
        {
            EnsureIsNotStopped();
            EnsureIsNotStopping();

            State = YielderState.Running;
            values.Enqueue(value);
        }

        public void Break()
        {
            EnsureIsNotStopped();
            EnsureIsNotStopping();

            State = values.Count == 0 ? YielderState.Stopped : YielderState.Stopping;
        }

        public T GetNext()
        {
            EnsureIsNotStopped();

            T value = values.Dequeue();
            if (values.Count == 0) State = State == YielderState.Stopping ? YielderState.Stopped : YielderState.Idle;

            return value;
        }

        public YielderState State { get; private set; }

        private void EnsureIsNotStopping()
        {
            if (State == YielderState.Stopping) throw new InvalidOperationException("Yielder is stopping");
        }

        private void EnsureIsNotStopped()
        {
            if (State == YielderState.Stopped) throw new InvalidOperationException("Yielder is stopped");
        }
    }

    enum YielderState
    {
        Idle,
        Running,
        Stopping,
        Stopped
    }
}