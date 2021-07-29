using System;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncStateSignaler : IDisposable
    {
        private TaskCompletionSource _taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        private object _mutex = new object();
        
        public AsyncStateSignaler(bool released)
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

        public Task WaitAsync()
        {
            lock (_mutex)
            {
                return _taskCompletionSource.Task;
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