using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class UnknownError : RpcError
    {
        public override string ErrorDescription
        {
            get => "This RPC error hasn't been documented yet";
        }

        public UnknownError(string errorMessage, int errorCode) : base(errorMessage, errorCode)
        {
        }

        public override string ToString()
        {
            return $"[{ErrorCode}][{ErrorMessage}][{ErrorDescription}]";
        }
    }
}