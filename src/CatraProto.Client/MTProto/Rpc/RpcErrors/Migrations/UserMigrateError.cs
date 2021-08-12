using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations
{
    public class UserMigrateError : RpcError, IMigrateError
    {
        public override string ErrorDescription { get; }
        public int DcId { get; }

        public UserMigrateError(string errorMessage, int errorCode) : base(errorMessage, errorCode)
        {
            if (errorMessage.Length > 13 && int.TryParse(errorMessage[13..], out var dcId))
            {
                DcId = dcId;
                ErrorDescription = $"User's data is located in datacenter {dcId}";
            }
            else
            {
                ErrorDescription = "User's data is located in another datacenter";
            }
        }
    }
}