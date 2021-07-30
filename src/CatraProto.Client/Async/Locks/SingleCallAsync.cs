using System;
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Locks
{
    public class SingleCallAsync<T>
    {
        private object _mutex = new object();
        private Task _currentCall;
        private Func<T, Task> _getTask;

        public SingleCallAsync(Func<T, Task> getTask)
        {
            _getTask = getTask;
        }
        
        public Task GetCall(T parameter)
        {
            lock (_mutex)
            {
                if (_currentCall is { IsCompleted: true } or null)
                {
                    return _currentCall = _getTask(parameter);
                }

                return _currentCall;
            }
        }
    }
}