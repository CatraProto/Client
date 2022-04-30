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
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Bodies;
using CatraProto.Client.Async.Loops.Exceptions;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Async.Signalers;
using Serilog;

namespace CatraProto.Client.Async.Loops
{
    public abstract class LoopController<TLoopState, TSignalState> : ILoop<TLoopState, TSignalState> where TLoopState : Enum where TSignalState : Enum
    {
        protected CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();
        protected LoopImplementation<TLoopState, TSignalState>? LoopImplementation { get; set; }
        protected AsyncStateSignaler<SignalBody<TSignalState>> StateSignaler { get; }
        protected object SharedLock { get; } = new object();
        protected TLoopState LoopState { get; set; }
        protected ILogger Logger { get; }

        protected readonly TaskCompletionSource ShutdownSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        public abstract bool SendSignal(TSignalState signal, [MaybeNullWhen(false)] out Task signalHandledTask);
        protected abstract void LoopFaulted(Exception e);
        protected abstract void SetLoopState(TLoopState state);

        public delegate void LoopFaultedEvent(LoopController<TLoopState, TSignalState> loopController, Exception e);
        public event LoopFaultedEvent? OnFaulted;

        protected LoopController(AsyncStateSignaler<SignalBody<TSignalState>> stateSignaler, TLoopState loopState, ILogger logger)
        {
            Logger = logger;
            StateSignaler = stateSignaler;
            LoopState = loopState;
        }

        public virtual bool BindTo(LoopImplementation<TLoopState, TSignalState> loopImplementation)
        {
            lock (SharedLock)
            {
                if (LoopImplementation is not null)
                {
                    return false;
                }

                loopImplementation.SetLoopHandler(StateSignaler, SetLoopState);
                Logger.Verbose("Loop bound to Implementation {Impl}", loopImplementation);
                LoopImplementation = loopImplementation;
                return true;
            }
        }

        protected virtual void OnStopped()
        {
            lock (SharedLock)
            {
                ShutdownSource.TrySetResult();
                StateSignaler.Dispose();
                CancellationTokenSource.Dispose();
            }
        }

        protected virtual void LaunchLoop()
        {
            if (LoopImplementation is null)
            {
                return;
            }

            Task.Run(async () =>
            {
                try
                {
                    await LoopImplementation.LoopAsync(CancellationTokenSource.Token);
                    if (!ShutdownSource.Task.IsCompleted)
                    {
                        Logger.Warning("Loop exited without setting itself as stopped, triggering faulted");
                        LoopFaulted(new LoopUngracefullyExited());
                    }
                }
                catch (Exception e)
                {
                    LoopFaulted(e);
                }
            });
        }

        public Task GetShutdownTask()
        {
            lock (SharedLock)
            {
                return ShutdownSource.Task;
            }
        }

        public TLoopState GetCurrentState()
        {
            lock (SharedLock)
            {
                return LoopState;
            }
        }

        protected bool IsOnFaultedSubscribed()
        {
            return OnFaulted != null;
        }

        protected virtual void TriggerFaulted(Exception e)
        {
            OnFaulted?.Invoke(this, e);
        }

        protected virtual void ClearSignals()
        {
            lock (SharedLock)
            {
                var firstRun = true;
                var lastReadState = StateSignaler.GetCurrentState(true);
                while (true)
                {
                    var nowState = StateSignaler.GetCurrentState(true);
                    if (nowState == lastReadState && !firstRun || nowState is null)
                    {
                        return;
                    }

                    nowState.SetCanceled();
                    lastReadState = nowState;
                    firstRun = false;
                }
            }
        }
    }
}