using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;

namespace CatraProto.Client.Async.Loops
{
    public enum LoopState
    {
        Stopped = -3,
        Stopping = -2,
        Starting = -1,
        Running = 0
    }

    public abstract class Loop : IDisposable
    {
        private AsyncLock _lock = new AsyncLock();
        public LoopState State { get; protected set; } = LoopState.Stopped;
        private TaskCompletionSource _shutdownSource { get; } = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        public Task ShutdownTask { get; }
        
        protected abstract void StopSignal();
        protected abstract Task StartSignal();

        public Loop()
        {
            ShutdownTask = _shutdownSource.Task;
        }
        
        public async Task Stop()
        {
            using (await _lock.LockAsync())
            {
                if (State == LoopState.Running)
                {
                    State = LoopState.Stopping;
                    StopSignal();
                    await ShutdownTask;
                    State = LoopState.Stopped;
                }   
            }
        }

        public async Task Start()
        {
            using (await _lock.LockAsync())
            {
                if (State == LoopState.Stopped)
                {
                    State = LoopState.Starting;
                    await StartSignal();
                    State = LoopState.Running;
                }   
            }
        }

        protected void SetLoopStopped()
        {
            State = LoopState.Stopped;
            _shutdownSource.TrySetResult();
        }
        
        public virtual void Dispose()
        {
            _lock?.Dispose();
            _shutdownSource.TrySetCanceled();
            ShutdownTask?.Dispose();
        }
    }
}