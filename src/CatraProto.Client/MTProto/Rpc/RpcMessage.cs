using System.Collections.Generic;
using CatraProto.Client.MTProto.Rpc.Interfaces;

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
                    Response = default;
                    Error = RpcError.GetRpcError(error);
                    break;
                default:
                    Response = (T)o;
                    break;
            }
        }
    }
}