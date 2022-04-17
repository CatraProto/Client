using System;

namespace CatraProto.Client.MTProto.Session.Interfaces
{
    internal abstract class SessionModel
    {
        protected object Mutex { get; }
        protected Action<SessionModel>? OnUpdated;

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

        public void RegisterOnUpdated(Action<SessionModel> action)
        {
            lock (Mutex)
            {
                OnUpdated += action;
            }
        }

        protected void OnDataUpdated()
        {
            lock (Mutex)
            {
                OnUpdated?.Invoke(this);
            }
        }
    }
}