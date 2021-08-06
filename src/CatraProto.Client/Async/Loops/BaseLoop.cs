using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Async.Signalers;

namespace CatraProto.Client.Async.Loops
{
    public abstract class BaseLoop<TLoopState, TStateSignaler> : IState<TLoopState>, ILoop, IDisposable where TLoopState : Enum where TStateSignaler : Enum
    {
        protected AsyncStateSignaler<TStateSignaler> StateSignaler { get; }
        private TaskCompletionSource _shutdownSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        private CancellationTokenSource? _cancellationTokenSource;
        protected readonly object SharedLock = new object();

        protected BaseLoop(AsyncStateSignaler<TStateSignaler> stateSignaler)
        {
            StateSignaler = stateSignaler;
        }

        public bool Start()
        {
            lock (SharedLock)
            {
                if (!CanStartLoop())
                {
                    return false;
                }
                
                if (_shutdownSource.Task.IsCompleted)
                {
                    _shutdownSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                }
                if (_cancellationTokenSource is null || _cancellationTokenSource.IsCancellationRequested)
                {
                    _cancellationTokenSource?.Dispose();
                    _cancellationTokenSource = new CancellationTokenSource();
                }
                
                StateSignaler.SetCancellationToken(_cancellationTokenSource.Token);
                OnLoopNewState(false);

                return true;
            }
        }

        public bool Stop()
        {
            lock (SharedLock)
            {
                if (!CanStopLoop())
                {
                    return false;
                }
                
                _cancellationTokenSource?.Cancel();
                OnLoopNewState(true);

                return true;
            }
        }

        protected virtual void SetLoopStopped()
        {
            lock (SharedLock)
            {
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

        
        protected abstract bool CanStartLoop();
        protected abstract bool CanStopLoop();
        protected abstract void OnLoopNewState(bool stopped);
        public abstract TLoopState GetCurrentState();

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