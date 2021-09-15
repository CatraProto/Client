using System.Diagnostics.CodeAnalysis;

namespace CatraProto.TL.Interfaces
{
    public abstract class ObjectProvider
    {
        public abstract int BoolTrueId { get; }
        public abstract int BoolFalseId { get; }
        public abstract int GzipPackedId { get; }
        public abstract int RpcResultId { get; }
        public abstract int VectorId { get; }

        /// <summary>
        ///     Provides an instance of the class assigned to its constructorId
        /// </summary>
        /// <param name="constructorId"></param>
        /// <returns>
        ///     Returns null if the constructorId is not assigned to any class otherwise, an instance of the class.
        /// </returns>
        public abstract IObject? ResolveConstructorId(int constructorId);
        public abstract byte[] GetGzippedBytes(IObject obj);
        public abstract IObject GetGzippedObject(byte[] compressedData);
        
        protected virtual bool InternalResolveConstructorId(int constructorId, [MaybeNullWhen(false)] out IObject obj)
        {
            obj = null;
            return false;
        }
    }
}