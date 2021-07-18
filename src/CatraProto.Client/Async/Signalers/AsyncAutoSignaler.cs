using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncAutoSignaler : IDisposable
    {
        private AsyncStateSignaler _signaler = new AsyncStateSignaler(true);
        private Timer _timer;
        private int _interval;
        private object _mutex = new object();

        public delegate void SignalEvent();
        public event SignalEvent OnSignal;

        public AsyncAutoSignaler(TimeSpan timeSpan)
        {
            _timer = new Timer(_ => Signal(), this, timeSpan.Milliseconds, timeSpan.Milliseconds);
            _interval = timeSpan.Milliseconds;
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

        public Task WaitSignal()
        {
            return _signaler.WaitSignal();
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _timer?.Dispose();
            }
        }
    }
}