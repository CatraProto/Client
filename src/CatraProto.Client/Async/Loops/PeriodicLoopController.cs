using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Timers;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using Serilog;

namespace CatraProto.Client.Async.Loops
{
    public class PeriodicLoopController : ResumableLoopController
    {
        private readonly bool _autoReset;
        private readonly Timer _timer;
        private bool _ignoreTimer;

        public PeriodicLoopController(TimeSpan period, ILogger logger, bool waitTick = true) : base(logger)
        {
            _timer = new Timer
            {
                Interval = period.TotalMilliseconds
            };
            _autoReset = !waitTick;
            _timer.AutoReset = !waitTick;
            _timer.Elapsed += (_, _) => OnTick();
        }

        private void OnTick()
        {
            lock (SharedLock)
            {
                if (_ignoreTimer)
                {
                    return;
                }

                SendSignal(ResumableSignalState.Resume, out _);
            }
        }

        protected override void OnStopped()
        {
            lock (SharedLock)
            {
                _timer.Dispose();
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
                _timer.Interval = timeSpan.TotalMilliseconds;
                _timer.Stop();
                _timer.Start();
            }
        }

        protected override void SetLoopState(ResumableLoopState state)
        {
            lock (SharedLock)
            {
                base.SetLoopState(state);
                if (_autoReset)
                {
                    return;
                }

                if (state is ResumableLoopState.Suspended)
                {
                    _timer.Start();
                }
            }
        }

        public override bool SendSignal(ResumableSignalState signal, [MaybeNullWhen(false)] out Task signalHandledTask)
        {
            lock (SharedLock)
            {
                if (base.SendSignal(signal, out signalHandledTask))
                {
                    switch (signal)
                    {
                        case ResumableSignalState.Resume:
                            base.SendSignal(ResumableSignalState.Suspend, out _);
                            break;
                        case ResumableSignalState.Start:
                            base.SendSignal(ResumableSignalState.Suspend, out _);
                            _timer.Start();
                            break;
                    }

                    if (signal is ResumableSignalState.Stop)
                    {
                        ToggleTimer(false);
                    }

                    if (_autoReset)
                    {
                        if (signal is ResumableSignalState.Resume)
                        {
                            _timer.Stop();
                        }
                    }

                    return true;
                }

                return false;
            }
        }
    }
}