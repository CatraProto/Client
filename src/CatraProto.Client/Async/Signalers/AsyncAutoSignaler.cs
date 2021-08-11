using System;
using System.Threading;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncAutoSignaler : IDisposable
    {
        public delegate void SignalEvent();

        private readonly AsyncSignaler _signaler = new AsyncSignaler(false);
        private readonly object _mutex = new object();
        private readonly Timer _timer;
        private int _interval;
        public event SignalEvent? OnSignal;

        public AsyncAutoSignaler(TimeSpan timeSpan)
        {
            _timer = new Timer(_ => Signal(), this, (int)timeSpan.TotalMilliseconds, (int)timeSpan.TotalMilliseconds);
            _interval = (int)timeSpan.TotalMilliseconds;
        }

        public void Signal()
        {
            lock (_mutex)
            {
                OnSignal?.Invoke();
                _signaler.SignalOnce();
                _timer.Change(_interval, _interval);
            }
        }

        public void ChangeInterval(TimeSpan timeSpan)
        {
            lock (_mutex)
            {
                _interval = (int)timeSpan.TotalMilliseconds;
                ResetTimer();
            }
        }

        public void ResetTimer()
        {
            lock (_mutex)
            {
                _timer.Change(_interval, _interval);
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