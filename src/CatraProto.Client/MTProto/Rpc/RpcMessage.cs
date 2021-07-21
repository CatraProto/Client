using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces;
using CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcMessage<T> : IRpcMessage
    {
        public bool RpcCallFailed
        {
            get => Error != null;
        }

        public IRpcError Error { get; private set; }
        public T Response { get; private set; }

        private static IRpcError ParseError(RpcError error)
        {
            switch (error)
            {
                default:
                    return new UnknownError(error.ErrorMessage, error.ErrorCode);
            }
        }

        public void SetResponse(object o)
        {
            switch (o)
            {
                case null:
                    return;
                case RpcError error:
                    Error = ParseError(error);
                    break;
                default:
                    Response = (T)o;
                    break;
            }
        }
    }
}