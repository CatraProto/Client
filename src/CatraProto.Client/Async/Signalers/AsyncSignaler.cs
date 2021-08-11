using System;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncSignaler : IDisposable
    {
        private TaskCompletionSource _taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly object _mutex = new object();

        public AsyncSignaler(bool released)
        {
            if (released)
            {
                SetSignal(true);
            }
        }

        public bool IsReleased()
        {
            lock (_mutex)
            {
                return _taskCompletionSource.Task.IsCompleted;
            }
        }

        public void SignalOnce()
        {
            lock (_mutex)
            {
                SetSignal(true);
                SetSignal(false);
            }
        }

        public void SetSignal(bool release)
        {
            lock (_mutex)
            {
                if (release)
                {
                    _taskCompletionSource.TrySetResult();
                }
                else
                {
                    if (_taskCompletionSource.Task.IsCompleted)
                    {
                        _taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                    }
                }
            }
        }

        public Task WaitAsync()
        {
            lock (_mutex)
            {
                return _taskCompletionSource.Task;
            }
        }

        public void Dispose()
        {
            _taskCompletionSource.TrySetCanceled();
        }
    }
}