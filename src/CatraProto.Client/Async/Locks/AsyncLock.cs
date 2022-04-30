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

namespace CatraProto.Client.Async.Locks
{
    public class AsyncLock : IDisposable
    {
        public bool IsTaken
        {
            get => _semaphoreSlim.CurrentCount == 0;
        }

        private readonly Releaser _releaser;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public AsyncLock()
        {
            _releaser = new Releaser(this);
        }

        public async Task<IDisposable> LockAsync(CancellationToken token = default)
        {
            await _semaphoreSlim.WaitAsync(token);
            return _releaser;
        }

        private void ReleaseLock()
        {
            _semaphoreSlim.Release();
        }

        public void Dispose()
        {
            _semaphoreSlim.Dispose();
        }

        private readonly struct Releaser : IDisposable
        {
            private readonly AsyncLock _asyncLock;

            internal Releaser(AsyncLock asyncLock)
            {
                _asyncLock = asyncLock;
            }

            public void Dispose()
            {
                _asyncLock.ReleaseLock();
            }
        }
    }
}