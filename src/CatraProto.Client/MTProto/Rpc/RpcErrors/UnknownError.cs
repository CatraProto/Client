using CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces;
using TlRpcError = CatraProto.Client.TL.Schemas.MTProto.RpcError;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class UnknownError : IRpcError
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }
        public string ErrorDescription { get => "This RPC error hasn't been documented yet"; }

        public UnknownError(string errorMessage, int errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}