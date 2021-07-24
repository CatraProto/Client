using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.TL.Schemas.CloudChats;

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

        public static RpcError GetRpcError(TL.Schemas.MTProto.RpcError error)
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

        public override string ToString()
        {
            return $"[{ErrorCode}][{ErrorDescription}]";
        }
    }
}