using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors
{
    internal class SerializationFailed : RpcError
    {
        public override string ErrorDescription { get; }

        public SerializationFailed(string parserError) : base("SERIALIZATION_FAILED", -10400)
        {
            ErrorDescription = parserError;
        }
    }
}
