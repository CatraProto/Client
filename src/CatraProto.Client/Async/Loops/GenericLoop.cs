using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Signalers;

namespace CatraProto.Client.Async.Loops
{
    public class GenericLoop : BaseLoop<LoopState, SignalState>
    {
        private LoopState _loopState = LoopState.Stopped;

        public GenericLoop() : base(new AsyncStateSignaler<SignalState>(SignalState.Stop))
        {
        }

        protected override bool CanStartLoop()
        {
            lock (SharedLock)
            {
                return _loopState == LoopState.Stopped;
            }
        }

        protected override bool CanStopLoop()
        {
            lock (SharedLock)
            {
                return _loopState == LoopState.Running;
            }
        }

        protected override void OnLoopNewState(bool stopped)
        {
            lock (SharedLock)
            {
                if (stopped)
                {
                    _loopState = LoopState.Stopped;
                    StateSignaler.Signal(SignalState.Stop);
                }
                else
                {
                    _loopState = LoopState.Running;
                    StateSignaler.Signal(SignalState.Start);
                }
            }
        }

        protected override void SetLoopStopped()
        {
            lock (SharedLock)
            {
                _loopState = LoopState.Stopped;
                base.SetLoopStopped();
            }
        }

        public override LoopState GetCurrentState()
        {
            lock (SharedLock)
            {
                return _loopState;
            }
        }
    }
}