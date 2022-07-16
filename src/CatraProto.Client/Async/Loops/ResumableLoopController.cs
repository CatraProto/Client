/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/


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

                switch (signal)
                {
                    case ResumableSignalState.Stop:
                        StateSignaler.Signal(SignalBody<ResumableSignalState>.FromSignal(signal, ShutdownSource));
                        signalHandledTask = ShutdownSource.Task;
                        CancellationTokenSource.Cancel();
                        break;
                    default:
                        StateSignaler.Signal(SignalBody<ResumableSignalState>.FromSignal(signal, out signalHandledTask));
                        break;
                }

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