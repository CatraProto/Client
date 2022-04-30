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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Locks
{
    public class NamedAsyncLock<T> : IDisposable where T : notnull
    {
        private readonly object _lock = new object();
        private readonly Dictionary<T, Counter<SemaphoreSlim>> _semaphores = new Dictionary<T, Counter<SemaphoreSlim>>();
        private bool _isDiposed = false;

        private SemaphoreSlim GetLock(T key)
        {
            lock (_lock)
            {
                ThrowIfDisposed();
                if (_semaphores.TryGetValue(key, out var semaphore))
                {
                    semaphore.IncreaseCount();
                    return semaphore.Item;
                }

                var semaphoreSlim = new SemaphoreSlim(1, 1);
                var counter = new Counter<SemaphoreSlim>(semaphoreSlim, 1);
                _semaphores.Add(key, counter);
                return semaphoreSlim;
            }
        }

        public bool IsLockTaken(T key)
        {
            lock (_lock)
            {
                ThrowIfDisposed();
                return _semaphores.TryGetValue(key, out _);
            }
        }

        internal void ReleaseLock(T key)
        {
            lock (_lock)
            {
                var counter = _semaphores[key];
                if (counter.RequestedTimesLock - 1 == 0)
                {
                    _semaphores.Remove(key);
                    counter.Item.Dispose();
                }
                else
                {
                    counter.DecreaseCount();
                    counter.Item.Release();
                }
            }
        }

        public async ValueTask<IDisposable> LockAsync(T key)
        {
            await GetLock(key).WaitAsync();
            return new Releaser<T>(key, this);
        }

        public void Dispose()
        {
            lock (_lock)
            {
                _isDiposed = true;
                foreach (var keyValuePair in _semaphores)
                {
                    keyValuePair.Value.Item.Dispose();
                }

                _semaphores.Clear();
            }
        }

        private void ThrowIfDisposed()
        {
            lock (_lock)
            {
                if (_isDiposed)
                {
                    throw new ObjectDisposedException("NamedAsyncLock");
                }
            }
        }

        private readonly struct Releaser<R> : IDisposable where R : notnull
        {
            private readonly R _releaseKey;
            private readonly NamedAsyncLock<R> _asyncLock;

            internal Releaser(R releaseKey, NamedAsyncLock<R> asyncLock)
            {
                _asyncLock = asyncLock;
                _releaseKey = releaseKey;
            }

            public void Dispose()
            {
                _asyncLock.ReleaseLock(_releaseKey);
            }
        }

        private class Counter<I>
        {
            public int RequestedTimesLock { get; private set; }
            public I Item { get; }
            private readonly object _mutex = new object();

            internal Counter(I item, int initialRequested = 0)
            {
                Item = item;
                RequestedTimesLock = initialRequested;
            }

            public void IncreaseCount()
            {
                lock (_mutex)
                {
                    RequestedTimesLock++;
                }
            }

            public void DecreaseCount()
            {
                lock (_mutex)
                {
                    RequestedTimesLock--;
                }
            }

            public void SetCount(int count)
            {
                lock (_mutex)
                {
                    RequestedTimesLock = count;
                }
            }
        }
    }
}