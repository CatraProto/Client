using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Bodies;
using CatraProto.Client.Async.Signalers;

namespace CatraProto.Client.Async.Loops.Interfaces
{
    public abstract class LoopImplementation<TLoopState, TSignalState> where TSignalState : Enum where TLoopState : Enum
    {
        protected AsyncStateSignaler<SignalBody<TSignalState>> StateSignaler
        {
            get
            {
                CheckIfBound();
                return _stateSignaler!;
            }
        }
        
        private AsyncStateSignaler<SignalBody<TSignalState>>? _stateSignaler;
        private Action<TLoopState>? _loopStateAction;
        public abstract Task LoopAsync(CancellationToken stoppingToken);
        public abstract override string ToString();
        public void SetLoopHandler(AsyncStateSignaler<SignalBody<TSignalState>> stateSignaler, Action<TLoopState> loopStateAction)
        {
            _loopStateAction = loopStateAction;
            _stateSignaler = stateSignaler;
        }
        
        private void CheckIfBound()
        {
            if (_stateSignaler is null)
            {
                throw new InvalidOperationException("The loop wasn't started or bound to a loop handler");
            }
        }

        protected void SetLoopState(TLoopState loopState)
        {
            CheckIfBound();
            _loopStateAction!.Invoke(loopState);
        }

        protected void SetSignalHandled(TLoopState newState, SignalBody<TSignalState> signalBody)
        {
            SetLoopState(newState);
            signalBody.SetHandled();
        }
    }
}