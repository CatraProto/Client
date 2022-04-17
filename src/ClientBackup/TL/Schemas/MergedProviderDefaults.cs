using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.MTProto.Deserializers;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.Database;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : ObjectProvider
    {
        public const int LayerId = 138;
        public override int VectorId
        {
            get => 481674261;
        }

        public override int BoolTrueId { get; } = -1720552011;
        public override int BoolFalseId { get; } = -1132882121;
        public override int GzipPackedId { get; } = GzipPacked.ConstructorId;
        public override int RpcResultId { get; } = RpcResult.ConstructorId;
        public static readonly MergedProvider Singleton = new MergedProvider();

        public override ReadResult<byte[]> GetGzippedBytes(IObject obj)
        {
            if (obj is not GzipPacked gzipPacked)
            {
                return new ReadResult<byte[]>($"The provided object was not {typeof(GzipPacked)}", CatraProto.TL.Results.ParserErrors.ExternalError);
            }

            return new ReadResult<byte[]>(gzipPacked.PackedData);
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
            }

            obj = null;
            return false;
        }

        private bool InternalGetNakedFromType(Type type, [MaybeNullWhen(false)] out IObject obj)
        {
            obj = null;
            return false;
        }
    }
}