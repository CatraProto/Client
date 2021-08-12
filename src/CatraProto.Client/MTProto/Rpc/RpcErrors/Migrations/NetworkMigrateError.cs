using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations
{
    public class NetworkMigrateError : RpcError, IMigrateError
    {
        public override string ErrorDescription { get; }
        public int DcId { get; }

        public NetworkMigrateError(string errorMessage, int errorCode) : base(errorMessage, errorCode)
        {
            if (errorMessage.Length > 16 && int.TryParse(errorMessage[16..], out var dcId))
            {
                DcId = dcId;
                ErrorDescription = $"Based on the phone number, the server chose dc{dcId} to continue authentication";
            }
            else
            {
                ErrorDescription = "Based on the phone number, the server choose another datacenter to continue authentication";
            }
        }
    }
}