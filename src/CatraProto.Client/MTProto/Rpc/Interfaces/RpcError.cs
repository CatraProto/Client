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

        public static RpcError GetRpcError(TL.Schemas.MTProto.RpcError error)
        {
            switch (error.ErrorMessage)
            {
                case "BOT_METHOD_INVALID":
                    return new BotMethodInvalidError(error.ErrorMessage, error.ErrorCode);
            }

            //TODO: Better way to handle error messages
            switch (error.ErrorMessage.Length)
            {
                case > 10 when error.ErrorMessage[..10] == "FLOOD_WAIT":
                    return new FloodWaitError(error.ErrorMessage, error.ErrorCode);
                case > 10:
                {
                    switch (error.ErrorMessage.Length)
                    {
                        case > 12 when error.ErrorMessage[..12] == "USER_MIGRATE":
                            return new UserMigrateError(error.ErrorMessage, error.ErrorCode);
                        case > 12:
                        {
                            switch (error.ErrorMessage.Length)
                            {
                                case > 13 when error.ErrorMessage[..13] == "PHONE_MIGRATE":
                                    return new PhoneMigrateError(error.ErrorMessage, error.ErrorCode);
                            }

                            switch (error.ErrorMessage.Length)
                            {
                                case > 16 when error.ErrorMessage[..15] == "NETWORK_MIGRATE":
                                    return new NetworkMigrateError(error.ErrorMessage, error.ErrorCode);
                            }

                            break;
                        }
                    }

                    break;
                }
            }

            return new UnknownError(error.ErrorMessage, error.ErrorCode);
        }

        public override string ToString()
        {
            return $"[{ErrorCode}][{ErrorMessage}][{ErrorDescription}]";
        }
    }
}