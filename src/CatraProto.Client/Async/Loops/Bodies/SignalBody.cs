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
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops.Bodies
{
    public class SignalBody<TSignal> where TSignal : Enum
    {
        public Task Task
        {
            get => _taskCompletionSource.Task;
        }

        public bool AlreadyHandled
        {
            get => _taskCompletionSource.Task.IsCompleted;
        }

        public TSignal Signal { get; }
        private readonly TaskCompletionSource _taskCompletionSource;

        private SignalBody(TSignal signal, TaskCompletionSource taskCompletionSource)
        {
            Signal = signal;
            _taskCompletionSource = taskCompletionSource;
        }

        public void SetHandled()
        {
            _taskCompletionSource.TrySetResult();
        }

        public void SetCanceled()
        {
            _taskCompletionSource.TrySetCanceled();
        }

        public static SignalBody<TSignal> FromSignal(TSignal signal, out Task signalCompletion)
        {
            var taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            signalCompletion = taskCompletionSource.Task;
            return new SignalBody<TSignal>(signal, taskCompletionSource);
        }

        public static SignalBody<TSignal> FromSignal(TSignal signal, TaskCompletionSource taskCompletionSource)
        {
            return new SignalBody<TSignal>(signal, taskCompletionSource);
        }
    }
}