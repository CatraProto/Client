using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors;

namespace CatraProto.Client.MTProto.Rpc.Parsers
{
    internal class BotMethodInvalidParser : RpcErrorParser
    {
        public BotMethodInvalidParser() : base(18)
        {
        }

        public override RpcError? GetError(TL.Schemas.MTProto.RpcError error)
        {
            if (!CheckPrerequisites(error.ErrorMessage))
            {
                return null;
            }

            return error.ErrorMessage == "BOT_METHOD_INVALID" ? new BotMethodInvalidError(error.ErrorMessage, error.ErrorCode) : null;
        }
    }
}