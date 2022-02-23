using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations
{
    public class NetworkMigrateError : RpcError, IMigrateError
    {
        public override string ErrorDescription { get; }
        public int DcId { get; }

        public NetworkMigrateError(string errorMessage, int errorCode, int dcId) : base(errorMessage, errorCode)
        {
            DcId = dcId;
            ErrorDescription = $"Based on the network, the server chose dc{dcId} to continue authentication";
        }
    }
}