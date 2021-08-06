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

        private Releaser _releaser;
        private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

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
        
        public void Dispose()
        {
            _semaphoreSlim?.Dispose();
        }
    }
}