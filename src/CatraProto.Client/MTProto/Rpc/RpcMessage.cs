using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.ObjectDeserializers;
using RpcError = CatraProto.Client.MTProto.Rpc.Interfaces.RpcError;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcMessage<T> : IRpcMessage
    {
        public bool RpcCallFailed
        {
            get => Error != null;
        }

        public RpcError? Error { get; private set; }
        public T? Response { get; internal set; }

        public void SetResponse(object o)
        {
            switch (o)
            {
                case IList<object> objects:
                    ((IRpcVector)Response!).Cast(objects);
                    break;
                case null:
                    return;
                case TL.Schemas.MTProto.RpcError error:
                    Error = RpcError.GetRpcError(error);
                    break;
                default:
                    Response = (T)o;
                    break;
            }
        }
    }
}