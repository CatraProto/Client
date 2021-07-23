using CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class BotMethodInvalidError : IRpcError
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }
        public string ErrorDescription { get => "Bots can't use this method"; }
        public BotMethodInvalidError(string errorMessage, int errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}