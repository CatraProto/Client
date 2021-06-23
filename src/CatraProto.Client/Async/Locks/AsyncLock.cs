using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Locks
{
	public class AsyncLock : IDisposable
	{
		private Releaser _releaser;
		private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

		public AsyncLock()
		{
			_releaser = new Releaser(this);
		}

		public bool IsTaken
		{
			get => _semaphoreSlim.CurrentCount == 0;
		}

		public void Dispose()
		{
			_semaphoreSlim?.Dispose();
		}

		public async Task<IDisposable> LockAsync()
		{
			await _semaphoreSlim.WaitAsync().ConfigureAwait(false);
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
	}
}