using System;

namespace CatraProto.Client.MTProto.Session.Interfaces
{
    abstract class SessionModel
    {
        protected object Mutex { get; }

        protected SessionModel(object mutex)
        {
            Mutex = mutex;
        }

        public T ComputeInLock<T>(Func<SessionModel, T> action)
        {
            lock (Mutex)
            {
                return action(this);
            }
        }
        
        public void ComputeInLock(Action<SessionModel> action)
        {
            lock (Mutex)
            {
                action(this);
            }
        }
    }
}