using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors
{
    public class BotMethodInvalidError : RpcError
    {
        public override string ErrorDescription
        {
            get => "Bots can't use this method";
        }

        public BotMethodInvalidError(string errorMessage, int errorCode) : base(errorMessage, errorCode)
        {
        }
    }
}