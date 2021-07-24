using CatraProto.Client.MTProto.Rpc.Interfaces;
using TlRpcError = CatraProto.Client.TL.Schemas.MTProto.RpcError;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class UnknownError : RpcError
    {
        public override int ErrorCode { get; }
        public override string ErrorMessage { get; }
        public override string ErrorDescription { get => "This RPC error hasn't been documented yet"; }

        public UnknownError(string errorMessage, int errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
        
        public override string ToString()
        {
            return $"[{ErrorCode}][{ErrorMessage}][{ErrorDescription}]";
        }
    }
}