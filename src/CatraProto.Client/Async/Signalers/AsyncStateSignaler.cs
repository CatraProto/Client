using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncStateSignaler<T> where T : System.Enum, IDisposable
    {
        private T _currentState;
        private TaskCompletionSource<T> _taskCompletionSource = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
        private object _mutex = new object();

        public AsyncStateSignaler(T currentState)
        {
            _currentState = currentState;
        }

        public Task<T> WaitAsync(CancellationToken token = default)
        {
            lock (_mutex)
            {
                return _taskCompletionSource.Task.WithCancellationToken(token);
            }
        }

        public async Task WaitForState(T state, CancellationToken token = default)
        {
            while (true)
            {
                if ((await WaitAsync(token)).Equals(state))
                {
                    return;
                }
            }
        }

        public T GetCurrentState()
        {
            lock (_mutex)
            {
                return _currentState;
            }
        }

        public void Set(T state, bool force = false)
        {
            lock (_mutex)
            {
                if (_currentState.Equals(state) && !force)
                {
                    return;
                }

                _currentState = state;
                _taskCompletionSource.TrySetResult(state);
                _taskCompletionSource = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _taskCompletionSource.TrySetCanceled();
                _taskCompletionSource = null;
            }
        }
    }
}