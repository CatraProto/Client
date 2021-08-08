using System;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Signalers;

namespace CatraProto.Client.Async.Loops
{
    public class PeriodicLoop : ResumableLoop
    {
        private readonly AsyncAutoSignaler _asyncAutoSignaler;
        private bool _ignoreTimer;

        public PeriodicLoop(TimeSpan period)
        {
            _asyncAutoSignaler = new AsyncAutoSignaler(period);
            _asyncAutoSignaler.OnSignal += OnAsyncAutoSignalerOnOnSignal;
        }

        public override bool Resume()
        {
            lock (SharedLock)
            {
                base.Resume();
                _ignoreTimer = false;
                _asyncAutoSignaler.ResetTimer();

                return true;
            }
        }

        public override bool Suspend()
        {
            lock (SharedLock)
            {
                base.Suspend();
                _ignoreTimer = true;

                return true;
            }
        }

        public void IgnoreTimer(bool ignore)
        {
            lock (SharedLock)
            {
                _ignoreTimer = ignore;
            }
        }

        private void OnAsyncAutoSignalerOnOnSignal()
        {
            lock (SharedLock)
            {
                if (_ignoreTimer)
                {
                    return;
                }

                base.Resume();
                base.Suspend();
            }
        }

        public void ChangeInterval(TimeSpan timeSpan)
        {
            lock (SharedLock)
            {
                base.Suspend();
                _asyncAutoSignaler.ChangeInterval(timeSpan);
            }
        }

        protected override void OnLoopNewState(bool stopped)
        {
            lock (SharedLock)
            {
                if (!stopped)
                {
                    IgnoreTimer(false);

                    ChangeLoopState(ResumableLoopState.Running);
                    StateSignaler.Signal(ResumableSignalState.Start);

                    base.Suspend();
                }
                else
                {
                    IgnoreTimer(true);
                    base.OnLoopNewState(true);
                }
            }
        }

        protected override void SetLoopStopped()
        {
            lock (SharedLock)
            {
                _ignoreTimer = true;
                base.SetLoopStopped();
            }
        }

        public override void Dispose()
        {
            lock (SharedLock)
            {
                base.Dispose();
                StateSignaler.Dispose();
                _asyncAutoSignaler.Dispose();
            }
        }
    }
}