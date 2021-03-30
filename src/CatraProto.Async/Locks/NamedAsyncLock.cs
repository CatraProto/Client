using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Async.Locks
{
    public class NamedAsyncLock<T>
    {
        private Dictionary<T, Counter<SemaphoreSlim>> _semaphores = new Dictionary<T, Counter<SemaphoreSlim>>();
        private SemaphoreSlim GetLock(T key)
        {
            lock (_semaphores)
            {
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

        internal void ReleaseLock(T key)
        {
            lock (_semaphores)
            {
                var counter = _semaphores[key];
                if (counter.RequestedTimesLock - 1 == 0)
                {
                    _semaphores.Remove(key);
                    counter.Item.Dispose();
                }
                else
                {
                    counter.Item.Release();
                }
            }
        }
        
        public async ValueTask<IDisposable> LockAsync(T key)
        {
            await GetLock(key).WaitAsync().ConfigureAwait(false);
            return new Releaser<T>(key, this);
        }

        private readonly struct Releaser<R> : IDisposable
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
            private readonly object _mutex = new object();
            public int RequestedTimesLock { get; private set; }
            public I Item { get; private set; }

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