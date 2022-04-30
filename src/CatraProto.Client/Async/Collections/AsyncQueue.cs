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
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Collections
{
    public class AsyncQueue<T> : IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(0, 1);
        private readonly List<T> _list = new List<T>();
        private readonly object _mutex = new object();
        private T? _lastInsertedElement;
        private T? _lastReadElement;
        private int _releaseCount;

        public void Enqueue(T item)
        {
            lock (_mutex)
            {
                _list.Add(item);
                _releaseCount++;
                _lastInsertedElement = item;
                ReleaseIfNecessary();
            }
        }

        public bool TryPeek([MaybeNullWhen(false)] out T item)
        {
            lock (_mutex)
            {
                if (_list.Count == 0)
                {
                    item = default;
                    return false;
                }

                item = _list[0];
                return true;
            }
        }

        public T Dequeue()
        {
            lock (_mutex)
            {
                if (TryDequeue(out var item))
                {
                    return item;
                }

                throw new Exception("Queue is empty");
            }
        }

        public bool TryDequeue([MaybeNullWhen(false)] out T item)
        {
            lock (_mutex)
            {
                if (TryPeek(out _))
                {
                    var temp = _list[0];
                    _list.RemoveAt(0);
                    _lastReadElement = temp;
                    _releaseCount--;
                    ReleaseIfNecessary();

                    item = temp;
                    return true;
                }

                item = default;
                return false;
            }
        }

        public async ValueTask<T> DequeueAsync(CancellationToken token = default)
        {
            while (true)
            {
                if (TryDequeue(out var item))
                {
                    return item!;
                }

                await _semaphoreSlim.WaitAsync(token);
            }
        }

        public int GetCount()
        {
            lock (_mutex)
            {
                return _list.Count;
            }
        }

        private void ReleaseIfNecessary()
        {
            lock (_mutex)
            {
                if (_semaphoreSlim.CurrentCount < 1 && _releaseCount > 0)
                {
                    _semaphoreSlim.Release();
                }
            }
        }

        public bool TryGetLastEnqueued([MaybeNullWhen(false)] out T item)
        {
            lock (_mutex)
            {
                if (_lastInsertedElement is null)
                {
                    item = default;
                    return false;
                }

                item = _lastInsertedElement;
                return true;
            }
        }

        public bool TryGetLastDequeued([MaybeNullWhen(false)] out T item)
        {
            lock (_mutex)
            {
                if (_lastReadElement is null)
                {
                    item = default;
                    return false;
                }

                item = _lastReadElement;
                return true;
            }
        }

        public bool TryGetLastInQueue([MaybeNullWhen(false)] out T item)
        {
            lock (_mutex)
            {
                if (_list.Count == 0)
                {
                    item = default;
                    return false;
                }

                item = _list[^1];
                return true;
            }
        }

        public bool TryGetFirstInQueue([MaybeNullWhen(false)] out T item)
        {
            lock (_mutex)
            {
                if (_list.Count == 0)
                {
                    item = default;
                    return false;
                }

                item = _list[0];
                return true;
            }
        }

        public void Dispose()
        {
            _semaphoreSlim.Dispose();
        }
    }
}