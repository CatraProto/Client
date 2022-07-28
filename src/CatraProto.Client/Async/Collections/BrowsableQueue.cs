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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CatraProto.Client.Async.Collections
{
    public class BrowsableQueue<T> : IEnumerable<BrowsableQueue<T>.QueuedItemHandle>
    {
        private readonly List<T> _list = new List<T>();
        private readonly object _mutex = new object();
        private BrowsableEnumerator? _lastEnumerator;
        private QueuedItemHandle? _lastHandle;
        private int _iteratorPosition;

        public int GetCount()
        {
            lock (_mutex)
            {
                return _list.Count;
            }
        }

        public int Enqueue(T item)
        {
            lock (_mutex)
            {
                _list.Add(item);
                return _list.Count;
            }
        }

        public bool TryPeek([MaybeNullWhen(false)] out QueuedItemHandle queuedItemHandle, bool advance = false)
        {
            lock (_mutex)
            {
                if (_list.Count - 1 >= _iteratorPosition)
                {
                    queuedItemHandle = _lastHandle = new QueuedItemHandle(_list[_iteratorPosition], this, advance);
                    if (advance)
                    {
                        _iteratorPosition++;
                    }

                    return true;
                }

                _lastHandle = null;
                _iteratorPosition = 0;
                queuedItemHandle = null;
                return false;
            }
        }

        public bool TryDequeue([MaybeNullWhen(false)] out T value)
        {
            lock (_mutex)
            {
                if (TryPeek(out var handle, true))
                {
                    value = handle.Item;
                    handle.DequeueItem();
                    return true;
                }

                value = default;
                return false;
            }
        }

        private void RemoveFromHandle(QueuedItemHandle queuedItemHandle, bool hadAdvanced)
        {
            lock (_mutex)
            {
                if (_lastHandle == null || queuedItemHandle != _lastHandle)
                {
                    throw new InvalidOperationException("Invalid item handle provided");
                }

                if (hadAdvanced)
                {
                    _iteratorPosition--;
                }

                _list.Remove(queuedItemHandle.Item);
            }
        }

        private void ResetEnumerator(bool resetEnumerator)
        {
            lock (_mutex)
            {
                _iteratorPosition = 0;
                if (resetEnumerator)
                {
                    _lastEnumerator = null;
                }
            }
        }

        public IEnumerator<QueuedItemHandle> GetEnumerator()
        {
            lock (_mutex)
            {
                if (_lastEnumerator != null)
                {
                    throw new InvalidOperationException("Multiple concurrent enumerators aren't supported");
                }

                return _lastEnumerator = new BrowsableEnumerator(this);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class BrowsableEnumerator : IEnumerator<QueuedItemHandle>
        {
            public QueuedItemHandle Current
            {
                get
                {
                    if (_queuedItemHandle == null)
                    {
                        throw new InvalidOperationException("Collection not yet iterated");
                    }

                    return _queuedItemHandle;
                }
            }

            object IEnumerator.Current
            {
                get => Current;
            }

            private readonly BrowsableQueue<T> _browsableQueue;
            private QueuedItemHandle? _queuedItemHandle;

            internal BrowsableEnumerator(BrowsableQueue<T> browsableQueue)
            {
                _browsableQueue = browsableQueue;
            }

            public bool MoveNext()
            {
                return _browsableQueue.TryPeek(out _queuedItemHandle, true);
            }

            public void Reset()
            {
                _browsableQueue.ResetEnumerator(false);
            }

            public void Dispose()
            {
                _browsableQueue.ResetEnumerator(true);
            }
        }

        public class QueuedItemHandle
        {
            public T Item { get; }
            private readonly BrowsableQueue<T> _browsableQueue;
            private readonly bool _hadAdvanced;

            internal QueuedItemHandle(T item, BrowsableQueue<T> browsableQueue, bool hadAdvanced)
            {
                _browsableQueue = browsableQueue;
                _hadAdvanced = hadAdvanced;
                Item = item;
            }

            public void DequeueItem()
            {
                _browsableQueue.RemoveFromHandle(this, _hadAdvanced);
            }
        }
    }
}