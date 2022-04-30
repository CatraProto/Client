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
using System.Timers;


namespace CatraProto.Client.Async.Signalers
{
    public class AsyncAutoSignaler : IDisposable
    {
        public delegate void SignalEvent();
        private readonly AsyncSignaler _signaler = new AsyncSignaler(false);
        private readonly object _mutex = new object();
        private readonly Timer _timer;
        public event SignalEvent? OnSignal;

        public AsyncAutoSignaler(TimeSpan timeSpan)
        {
            _timer = new Timer
            {
                Interval = timeSpan.TotalMilliseconds,
                AutoReset = true
            };
            _timer.Elapsed += (_, _) => Signal();
        }

        public void Signal()
        {
            lock (_mutex)
            {
                OnSignal?.Invoke();
                _signaler.SignalOnce();
            }
        }

        public void ChangeInterval(TimeSpan timeSpan)
        {
            lock (_mutex)
            {
                _timer.Interval = timeSpan.TotalMilliseconds;
            }
        }

        public void Start()
        {
            lock (_mutex)
            {
                _timer.Start();
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _timer.Dispose();
                _signaler.Dispose();
            }
        }
    }
}