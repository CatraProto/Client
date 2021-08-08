using System;

namespace CatraProto.Client.Async.Loops.Interfaces
{
    public interface IState<out T> where T : Enum
    {
        public T GetCurrentState();
    }
}