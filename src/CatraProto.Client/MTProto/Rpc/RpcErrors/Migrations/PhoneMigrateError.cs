using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations
{
    public class PhoneMigrateError : RpcError, IMigrateError
    {
        public override string ErrorDescription { get; }
        public int DcId { get; }

        public PhoneMigrateError(string errorMessage, int errorCode) : base(errorMessage, errorCode)
        {
            if (errorMessage.Length > 14 && int.TryParse(errorMessage[14..], out var dcId))
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