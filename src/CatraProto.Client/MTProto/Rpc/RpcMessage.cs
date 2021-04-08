using System.Text.RegularExpressions;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces;
using CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcMessage<T>
    {
        public IRpcError Error { get; }
        public T Response { get; }
        public bool RpcCallFailed => Error != null;
        
        private RpcMessage(IRpcError error, T response)
        {
            Error = error;
            Response = response;
        }

        internal static RpcMessage<T> Create(RpcError error, T response)
        {
            var rpcMessage = new RpcMessage<T>(ParseError(error), response);
            return rpcMessage;
        }

        private static IRpcError ParseError(RpcError error)
        {
            if (error == null) return null;
            return new UnknownError(error.ErrorMessage, error.ErrorCode);
        }
    }
}