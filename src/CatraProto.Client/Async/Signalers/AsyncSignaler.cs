using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncSignaler : IDisposable
    {
        private TaskCompletionSource _taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        private object _mutex = new object();

        public AsyncSignaler(bool released)
        {
            if (released)
            {
                SetSignal(true);
            }
        }

        public void SignalOnce()
        {
            SetSignal(true);
            SetSignal(false);
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

        public Task WaitAsync(CancellationToken token = default)
        {
            lock (_mutex)
            {
                return new Task(async() => await _taskCompletionSource.Task, token);
            }
        }

        public async Task WaitAndSignalAsync()
        {
            await WaitAsync();
            SetSignal(false);
        }

        public void Dispose()
        {
            _taskCompletionSource.TrySetCanceled();
        }
    }
}