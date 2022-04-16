using System;
using CatraProto.TL.Results;

namespace CatraProto.TL.Interfaces
{
    public abstract class ObjectProvider
    {
        public abstract int BoolTrueId { get; }
        public abstract int BoolFalseId { get; }
        public abstract int GzipPackedId { get; }
        public abstract int RpcResultId { get; }
        public abstract int VectorId { get; }

        public abstract IObject? ResolveConstructorId(int constructorId);
        public abstract ReadResult<byte[]> GetGzippedBytes(IObject obj);
        public abstract IObject GetGzippedObject(byte[] compressedData);
        public abstract IObject? GetNakedFromType(Type type);
    }
}