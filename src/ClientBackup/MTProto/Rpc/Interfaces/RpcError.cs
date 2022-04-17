using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations;

namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    public abstract class RpcError
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }
        public abstract string ErrorDescription { get; }

        protected RpcError(string errorMessage, int errorCode)
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