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

        public RpcError Error { get; private set; }
        public T Response { get; internal set; }

        private static RpcError ParseError(TL.Schemas.MTProto.RpcError error)
        {
            switch (error.ErrorMessage)
            {
                case "BOT_METHOD_INVALID":
                    return new BotMethodInvalidError(error.ErrorMessage, error.ErrorCode);
            }

            if (error.ErrorMessage.Length > 10)
            {
                if (error.ErrorMessage[..10] == "FLOOD_WAIT")
                {
                    return new FloodWaitError(error.ErrorMessage, error.ErrorCode);
                }
            }

            return new UnknownError(error.ErrorMessage, error.ErrorCode);
        }

        public void SetResponse(object o)
        {
            switch (o)
            {
                case IList<object> objects:
                    ((IRpcVector)Response).Cast(objects);
                    break;
                case null:
                    return;
                case TL.Schemas.MTProto.RpcError error:
                    Error = ParseError(error);
                    break;
                default:
                    Response = (T)o;
                    break;
            }
        }
    }
}