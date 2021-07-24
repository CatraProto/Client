using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class BotMethodInvalidError : RpcError
    {
        public override int ErrorCode { get; }
        public override string ErrorMessage { get; }
        public override string ErrorDescription { get => "Bots can't use this method"; }

        public BotMethodInvalidError(string errorMessage, int errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}