using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops
{
    public enum LoopState
    {
        Stopped = -3,
        Stopping = -2,
        Starting = -1,
        Running = 0
    }

    public abstract class Loop
    {
        public Task ShutdownTask
        {
            get => _shutdownSource.Task;
        }

        private TaskCompletionSource _shutdownSource { get; } = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        public LoopState State { get; protected set; } = LoopState.Stopped;

        protected abstract void StopSignal();
        protected abstract Task StartSignal();

        public async Task StopAsync()
        {
            if (State == LoopState.Running)
            {
                State = LoopState.Stopping;
                StopSignal();
                await ShutdownTask;
                State = LoopState.Stopped;
            }
        }

        public async Task StartAsync()
        {
            if (State == LoopState.Stopped)
            {
                State = LoopState.Starting;
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