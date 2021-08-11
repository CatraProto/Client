using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : ObjectProvider
    {
        public static readonly MergedProvider Singleton = new MergedProvider();
        public override int BoolTrueId { get; init; } = BoolTrue.StaticConstructorId;
        public override int BoolFalseId { get; init; } = BoolFalse.StaticConstructorId;
        public override int VectorId { get; init; } = 481674261;

        protected override bool InternalResolveConstructorId(int constructorId, [MaybeNullWhen(false)] out IObject? obj)
        {
            switch (constructorId)
            {
                case -212046591:
                    obj = new RpcObject();
                    return true;
            }

            obj = null;
            return false;
        }
    }
}