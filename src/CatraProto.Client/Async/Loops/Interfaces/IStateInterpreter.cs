using System;

namespace CatraProto.Client.Async.Loops.Interfaces
{
    public interface IStateInterpreter<T> where T : Enum
    {
        public bool IsStateStop(T state);
        public bool IsStateStart(T state);
    }
}