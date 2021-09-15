using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Collections
{
    public class AsyncQueue<T> : IDisposable
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(0, 1);
        private readonly List<T> _list = new List<T>();
        private readonly object _mutex = new object();
        private T? _lastReadElement;
        private int _releaseCount;

        public void Enqueue(T item)
        {
            lock (_mutex)
            {
                _list.Add(item);
                _releaseCount++;
                ReleaseIfNecessary();
            }
        }

        public T Dequeue()
        {
            lock (_mutex)
            {
                var temp = _list[0];
                _list.RemoveAt(0);

                _lastReadElement = temp;

                _releaseCount--;
                ReleaseIfNecessary();
                return temp;
            }
        }

        public bool TryDequeue(out T? item)
        {
            lock (_mutex)
            {
                if (_list.Count == 0)
                {
                    item = default;
                    return false;
                }

                item = Dequeue();
                return true;
            }
        }

        public async ValueTask<T> DequeueAsync(CancellationToken token = default)
        {
            while (true)
            {
                Debug.WriteLine("HIT!");
                if (TryDequeue(out var item))
                {
                    return item!;
                }

                await _semaphoreSlim.WaitAsync(token);
                Debug.WriteLine("Waiting for dequeue");
            }
        }

        public T? GetLastReadElement()
        {
            lock (_mutex)
            {
                return _lastReadElement;
            }
        }

        public bool TryGetLastElement(out T? item)
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

        public bool TryGetFirstElement(out T? item)
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

        public void Dispose()
        {
            _semaphoreSlim.Dispose();
        }
    }
}