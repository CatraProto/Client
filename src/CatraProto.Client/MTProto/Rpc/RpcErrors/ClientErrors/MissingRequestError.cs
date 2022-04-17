using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors
{
    public class MissingRequestError : RpcError
    {
        public override string ErrorDescription { get; } = "";

        public MissingRequestError() : base("REQUEST_NOT_FOUND", -10404)
        {
        }
    }
}
