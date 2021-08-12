using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Collections;
using CatraProto.Client.Async.Signalers.Interfaces;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncStateSignaler<T> : IStateSignaler<T>, IDisposable where T : Enum
    {
        private readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;
        private readonly AsyncQueue<T> _asyncQueue = new AsyncQueue<T>();
        private readonly object _mutex = new object();
        private CancellationToken? _cancellationToken;
        private bool _isObjectDisposed;

        public AsyncStateSignaler(T initialState)
        {
            _asyncQueue.Enqueue(initialState);
        }

        public void SetCancellationToken(CancellationToken cancellationToken)
        {
            lock (_mutex)
            {
                ThrowIfDisposed();
                _cancellationToken = cancellationToken;
            }
        }

        public T GetCurrentState(bool setAsRead)
        {
            lock (_mutex)
            {
                ThrowIfDisposed();

                T toReturn;
                if (_asyncQueue.TryGetFirstElement(out var item))
                {
                    toReturn = item!;
                    if (setAsRead)
                    {
                        _asyncQueue.Dequeue();
                    }
                }
                else
                {
                    toReturn = _asyncQueue.GetLastReadElement()!;
                }

                return toReturn;
            }
        }

        public void Signal(T state, bool force)
        {
            lock (_mutex)
            {
                ThrowIfDisposed();
                if (_asyncQueue.TryGetLastElement(out var lastState))
                {
                    if (_equalityComparer.Equals(state, lastState) && !force)
                    {
                        return;
                    }
                }

                _asyncQueue.Enqueue(state);
            }
        }

        public async Task<T> WaitStateAsync(CancellationToken token = default, params T[] targetStates)
        {
            while (true)
            {
                var currentState = await WaitAsync(token);
                if (IsStateInArray(targetStates, currentState, out T? foundState))
                {
                    return foundState!;
                }
            }
        }

        private bool IsStateInArray(T[] states, T targetState, out T? foundState)
        {
            for (var index = 0; index < states.Length; index++)
            {
                var state = states[index];
                if (_equalityComparer.Equals(state, targetState))
                {
                    foundState = state;
                    return true;
                }
            }

            foundState = default;
            return false;
        }

        private void ThrowIfDisposed()
        {
            lock (_mutex)
            {
                if (!_isObjectDisposed)
                {
                    return;
                }

                if (_cancellationToken != null)
                {
                    throw new OperationCanceledException(_cancellationToken.Value);
                }
                else
                {
                    throw new ObjectDisposedException("AsyncStateSignaler");
                }
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _isObjectDisposed = true;
                _asyncQueue.Dispose();
            }
        }

        public async Task<T> WaitAsync(CancellationToken token = default)
        {
            Task<T> task;
            lock (_mutex)
            {
                task = _asyncQueue.DequeueAsync(token);
            }

            try
            {
                return await task;
            }
            catch (ObjectDisposedException)
            {
                ThrowIfDisposed();

                //unreachable
                return default!;
            }
        }

        public void Signal(T state)
        {
            lock (_mutex)
            {
                Signal(state, false);
            }
        }
    }
}