using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations
{
    public class PhoneMigrateError : RpcError, IMigrateError
    {
        public override string ErrorDescription { get; }
        public int DcId { get; }

        public PhoneMigrateError(string errorMessage, int errorCode, int dcId) : base(errorMessage, errorCode)
        {
            DcId = dcId;
            ErrorDescription = $"Based on the phone number, the server chose dc{dcId} to continue authentication";
        }
    }
}