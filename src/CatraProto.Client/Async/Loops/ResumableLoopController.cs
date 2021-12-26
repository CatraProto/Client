using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Bodies;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Signalers;
using Serilog;

namespace CatraProto.Client.Async.Loops
{
    public class ResumableLoopController : LoopController<ResumableLoopState, ResumableSignalState>
    {
        public ResumableLoopController(ILogger logger) : base(new AsyncStateSignaler<SignalBody<ResumableSignalState>>(null), ResumableLoopState.NotYetStarted, logger)
        {
        }

        public override bool SendSignal(ResumableSignalState signal, [MaybeNullWhen(false)] out Task signalHandledTask)
        {
            signalHandledTask = null;
            lock (SharedLock)
            {
                if (LoopImplementation is null)
                {
                    return false;
                }

                if (GetCurrentState() is ResumableLoopState.Stopped or ResumableLoopState.Faulted)
                {
                    return false;
                }
                
                var lastSent = StateSignaler.GetLastSignaled();
                if (lastSent is null && signal is not ResumableSignalState.Start)
                {
                    return false;
                }
                
                switch (signal)
                {
                    case ResumableSignalState.Start when lastSent is not null:
                        return false;
                    case ResumableSignalState.Resume when lastSent?.Signal is not ResumableSignalState.Suspend:
                        return false;
                    case ResumableSignalState.Suspend when lastSent?.Signal is not ResumableSignalState.Start and not ResumableSignalState.Resume:
                        return false;
                    case ResumableSignalState.Stop when lastSent?.Signal is ResumableSignalState.Stop:
                        return false;
                }
                
                StateSignaler.Signal(SignalBody<ResumableSignalState>.FromSignal(signal, out signalHandledTask));
                if (signal is ResumableSignalState.Start)
                {
                    Logger.Verbose("Received Start signal, starting loop");
                    LaunchLoop();
                }
                
                return true;
            }
        }

        protected override void LoopFaulted(Exception e)
        {
            lock (SharedLock)
            {
                if (!IsOnFaultedSubscribed())
                {
                    Logger.Error(e, "Exception thrown while running on loop {Impl}", LoopImplementation!);
                }
                
                LoopState = ResumableLoopState.Faulted;
                OnStopped();
                ClearSignals();
                TriggerFaulted(e);
            }
        }

        protected override void SetLoopState(ResumableLoopState state)
        {
            lock (SharedLock)
            {
                if (state == ResumableLoopState.Stopped)
                {
                    OnStopped();
                }

                LoopState = state;
            }
        }
    }
}