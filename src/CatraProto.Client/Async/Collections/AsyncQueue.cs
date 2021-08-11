using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Collections
{
    public class AsyncQueue<T> : IDisposable
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(0, 1);
        private readonly object _mutex = new object();
        private int _releaseCount;

        public void Enqueue(T item)
        {
            lock (_mutex)
            {
                _queue.Enqueue(item);
                _releaseCount++;
                ReleaseIfNecessary();
            }
        }

        public bool TryDequeue(out T? item)
        {
            lock (_mutex)
            {
                if (!_queue.TryDequeue(out item))
                {
                    return false;
                }

                _releaseCount--;
                ReleaseIfNecessary();
                return true;
            }
        }

        public async Task<T> DequeueAsync(CancellationToken token = default)
        {
            await _semaphoreSlim.WaitAsync(token);
            lock (_mutex)
            {
                _releaseCount--;
                ReleaseIfNecessary();
                return _queue.Dequeue();
            }
        }

        public int GetCount()
        {
            lock (_mutex)
            {
                return _queue.Count;
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