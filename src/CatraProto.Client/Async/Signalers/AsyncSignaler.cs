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

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncSignaler : IDisposable
    {
        private TaskCompletionSource _taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly object _mutex = new object();

        public AsyncSignaler(bool released)
        {
            if (released)
            {
                SetSignal(true);
            }
        }

        public bool IsReleased()
        {
            lock (_mutex)
            {
                return _taskCompletionSource.Task.IsCompleted;
            }
        }

        public void SignalOnce()
        {
            lock (_mutex)
            {
                SetSignal(true);
                SetSignal(false);
            }
        }

        public void SetSignal(bool release)
        {
            lock (_mutex)
            {
                if (release)
                {
                    _taskCompletionSource.TrySetResult();
                }
                else
                {
                    if (_taskCompletionSource.Task.IsCompleted)
                    {
                        _taskCompletionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                    }
                }
            }
        }

        public Task WaitAsync()
        {
            lock (_mutex)
            {
                return _taskCompletionSource.Task;
            }
        }

        public void Dispose()
        {
            _taskCompletionSource.TrySetCanceled();
        }
    }
}