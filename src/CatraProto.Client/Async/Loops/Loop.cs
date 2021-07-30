using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops
{
    public enum LoopState
    {
        Stopped = 0,
        Running = 1
    }

    public abstract class Loop
    {
        public Task ShutdownTask
        {
            get => _shutdownSource.Task;
        }
        
        public LoopState State { get; protected set; } = LoopState.Stopped;
        private TaskCompletionSource _shutdownSource { get; set; } = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        protected abstract void StopSignal();
        protected abstract Task StartSignal();

        public async Task StopAsync()
        {
            if (State == LoopState.Running)
            {
                StopSignal();
                await ShutdownTask;
                State = LoopState.Stopped;
            }
        }

        public async Task StartAsync()
        {
            if (State == LoopState.Stopped)
            {
                if (_shutdownSource.Task.IsCompleted)
                {
                    _shutdownSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                }
                
                await StartSignal();
                State = LoopState.Running;
            }
        }

        protected void SetLoopStopped()
        {
            State = LoopState.Stopped;
            _shutdownSource.TrySetResult();
        }
    }
}