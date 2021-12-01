using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.Async.Signalers;
using Serilog;

namespace CatraProto.Client.Async.Loops
{
    public class PeriodicLoopController : ResumableLoopController
    {
        private readonly AsyncAutoSignaler _asyncAutoSignaler;
        private bool _ignoreTimer;

        public PeriodicLoopController(TimeSpan period, ILogger logger) : base(logger)
        {
            _asyncAutoSignaler = new AsyncAutoSignaler(period);
            _asyncAutoSignaler.OnSignal += OnTick;
        }

        private void OnTick()
        {
            lock (SharedLock)
            {
                if (_ignoreTimer)
                {
                    return;
                }

                if (base.SendSignal(ResumableSignalState.Resume, out _))
                {
                    base.SendSignal(ResumableSignalState.Suspend, out _);
                }
            }
        }

        protected override void OnStopped()
        {
            lock (SharedLock)
            {
                _asyncAutoSignaler?.Dispose();
                base.OnStopped();
            }
        }

        public void ToggleTimer(bool toggle)
        {
            lock (SharedLock)
            {
                _ignoreTimer = !toggle;
            }
        }

        public void ChangeInterval(TimeSpan timeSpan)
        {
            lock (SharedLock)
            {
                _asyncAutoSignaler.ChangeInterval(timeSpan);
            }
        }

        public override bool SendSignal(ResumableSignalState signal, [MaybeNullWhen(false)] out Task signalHandledTask)
        {
            lock (SharedLock)
            {
                if (base.SendSignal(signal, out signalHandledTask))
                {
                    if (signal is ResumableSignalState.Start)
                    {
                        base.SendSignal(ResumableSignalState.Suspend, out _);
                        _asyncAutoSignaler.Start();
                    }

                    return true;
                }
            
                return false;   
            }
        }
    }

    /*protected override void OnLoopNewState(bool stopped)
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
    }*/
}
