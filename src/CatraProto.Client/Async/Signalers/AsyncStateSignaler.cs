using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Signalers.Interfaces;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncStateSignaler<T> : IStateSignaler<T>, IDisposable where T : Enum
    {
        private T _currentState;
        private TaskCompletionSource<T> _taskCompletionSource = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly object _mutex = new object();
        private CancellationToken? _cancellationToken;

        public AsyncStateSignaler(T currentState)
        {
            _currentState = currentState;
        }

        private void ThrowIfCancelled()
        {
            lock (_mutex)
            {
                if (_taskCompletionSource is null)
                {
                    throw new ObjectDisposedException("Object disposed");
                }

                if (_taskCompletionSource.Task.IsCanceled)
                {
                    _taskCompletionSource.Task.GetAwaiter().GetResult();
                }
            }
        }

        public Task IsStateWaitAsync(T state)
        {
            lock (_mutex)
            {
                return _currentState.Equals(state) ? Task.CompletedTask : WaitAsync();
            }
        }

        public T GetCurrentState()
        {
            lock (_mutex)
            {
                ThrowIfCancelled();
                return _currentState;
            }
        }

        public void Signal(T state, bool force)
        {
            lock (_mutex)
            {
                if (GetCurrentState().Equals(state) && !force)
                {
                    return;
                }

                _currentState = state;
                _taskCompletionSource.TrySetResult(state);
                _taskCompletionSource = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
            }
        }

        public void SetCancellationToken(CancellationToken? cancellationToken)
        {
            lock (_mutex)
            {
                _cancellationToken = cancellationToken;
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _taskCompletionSource.TrySetCanceled(_cancellationToken ?? CancellationToken.None);
            }
        }

        public Task<T> WaitAsync(CancellationToken token = default)
        {
            lock (_mutex)
            {
                ThrowIfCancelled();
                return _taskCompletionSource.Task.WithCancellationToken(token);
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