using System;

namespace CatraProto.TL.Interfaces
{
    public interface IMethod<T> : IObject
    {
        public bool IsVector { get; init; }
        public Type Type { get; init; }
    }
}