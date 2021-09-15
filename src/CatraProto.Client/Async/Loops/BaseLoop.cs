using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Async.Signalers;

namespace CatraProto.Client.Async.Loops
{
    public abstract class BaseLoop<TLoopState, TSignalState> : IState<TLoopState>, ILoop<TSignalState>, IDisposable where TLoopState : Enum where TSignalState : Enum
    {
        protected AsyncStateSignaler<TSignalState> StateSignaler { get; }
        private TaskCompletionSource _shutdownSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        private CancellationTokenSource? _cancellationTokenSource;
        protected readonly object SharedLock = new object();
        public abstract void SendSignal(TSignalState state);
        protected abstract bool CanStartLoop();
        protected abstract bool CanStopLoop();
        public abstract TLoopState GetCurrentState();
        protected abstract void SetLoopState(TLoopState state);

        protected BaseLoop(AsyncStateSignaler<TSignalState> stateSignaler)
        {
            StateSignaler = stateSignaler;
        }

        protected void OnStart()
        {
            lock (SharedLock)
            {
                if (_shutdownSource.Task.IsCompleted)
                {
                    _shutdownSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                }

                if (_cancellationTokenSource is not null && !_cancellationTokenSource.IsCancellationRequested)
                {
                    return;
                }

                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = new CancellationTokenSource();
            }
        }

        public void OnStop()
        {
            lock (SharedLock)
            {
                _cancellationTokenSource?.Cancel();
                _shutdownSource.TrySetResult();
            }
        }
        
        public Task GetShutdownTask()
        {
            lock (SharedLock)
            {
                return _shutdownSource.Task;
            }
        }

        public CancellationToken GetShutdownToken()
        {
            lock (SharedLock)
            {
                return _cancellationTokenSource!.Token;
            }
        }
        
        public virtual void Dispose()
        {
            lock (SharedLock)
            {
                _shutdownSource.TrySetCanceled();
                _cancellationTokenSource?.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}