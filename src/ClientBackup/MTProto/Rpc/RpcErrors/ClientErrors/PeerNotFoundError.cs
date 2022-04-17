using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors
{
    public class PeerNotFoundError : RpcError
    {
        public override string ErrorDescription { get; }
        public long Id { get; }
        public PeerType Type { get; }

        public PeerNotFoundError(long id, PeerType peerType) : base("PEER_NOT_FOUND", -10404)
        {
            Id = id;
            Type = peerType;
            ErrorDescription = $"Couldn't find peer {id} of type {Type}";
        }
    }
}