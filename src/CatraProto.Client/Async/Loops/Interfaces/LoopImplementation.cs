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