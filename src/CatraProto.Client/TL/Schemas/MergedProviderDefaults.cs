using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.MTProto.Deserializers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.Database;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : ObjectProvider
    {
        public const int LayerId = 135;
        public static readonly MergedProvider Singleton = new MergedProvider();
        public override int BoolTrueId { get; } = -1132882121;
        public override int BoolFalseId { get; } = -1720552011;
        public override int GzipPackedId { get; } = GzipPacked.StaticConstructorId;
        public override int RpcResultId { get; } = RpcResult.StaticConstructorId;

        public override int VectorId
        {
            get => 481674261;
        }

        public override byte[] GetGzippedBytes(IObject obj)
        {
            if (obj is not GzipPacked gzipPacked)
            {
                throw new InvalidOperationException($"The provided object was not {typeof(GzipPacked)}");
            }

            return gzipPacked.PackedData;
        }

        public override IObject GetGzippedObject(byte[] compressedData)
        {
            return new GzipPacked { PackedData = compressedData };
        }

        private bool InternalResolveConstructorId(int constructorId, [MaybeNullWhen(false)] out IObject obj)
        {
            switch (constructorId)
            {
                case 1823163441:
                    obj = new DbPeer();
                    return true;
                case 1111983006:
                    obj = new DbPeerFull();
                    return true;
                case -212046591:
                    obj = new RpcObject();
                    return true;
            }

            obj = null;
            return false;
        }

        private bool InternalGetNakedFromType(Type type, [MaybeNullWhen(false)] out IObject obj)
        {
            if (type == typeof(MsgContainerDeserializer))
            {
                obj = new MsgContainerDeserializer();
                return true;
            }

            obj = null;
            return false;
        }
    }
}