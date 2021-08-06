using System;
using CatraProto.Client.Async.Signalers;

namespace CatraProto.Client.Async.Loops.Interfaces
{
    public interface IStateSignaler<T> where T : Enum
    {
        protected AsyncStateSignaler<T> StateSignaler { get; }
    }
}