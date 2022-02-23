using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.CatraErrors
{
    public class CantResolvePeer : RpcError
    {
        public override string ErrorDescription { get; }
        public long Id { get; }
        public PeerType Type { get; }

        public CantResolvePeer(long id, PeerType peerType) : base("Could not resolve provided peer id", 0)
        {
            Id = id;
            Type = peerType;
            ErrorDescription = $"Couldn't find peer {id} of type {Type}";
        }
    }
}