using System;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas
{
    partial class MergedProvider : ObjectProvider
    {
        public static readonly MergedProvider Singleton = new MergedProvider();
        public override Type BoolTrue { get; init; } = typeof(BoolTrue);
        public override Type BoolFalse { get; init; } = typeof(BoolFalse);
        public override int VectorId { get; init; } = 481674261;
        
        protected override bool InternalResolveConstructorId(int constructorId, out IObject? obj)
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