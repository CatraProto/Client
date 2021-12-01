using System;
using System.Timers;


namespace CatraProto.Client.Async.Signalers
{
    public class AsyncAutoSignaler : IDisposable
    {
        public delegate void SignalEvent();
        private readonly AsyncSignaler _signaler = new AsyncSignaler(false);
        private readonly object _mutex = new object();
        private readonly Timer _timer;
        public event SignalEvent? OnSignal;

        public AsyncAutoSignaler(TimeSpan timeSpan)
        {
            _timer = new Timer();
            _timer.Interval = timeSpan.TotalMilliseconds;
            _timer.AutoReset = true;
            _timer.Elapsed += (_, _) => Signal();
        }

        public void Signal()
        {
            lock (_mutex)
            {
                OnSignal?.Invoke();
                _signaler.SignalOnce();
            }
        }

        public void ChangeInterval(TimeSpan timeSpan)
        {
            lock (_mutex)
            {
                _timer.Interval = timeSpan.TotalMilliseconds;
            }
        }

        public void Start()
        {
            lock (_mutex)
            {
                _timer.Start();
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