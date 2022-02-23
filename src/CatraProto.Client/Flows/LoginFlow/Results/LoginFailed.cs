using CatraProto.Client.Flows.LoginFlow.Interfaces;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.Flows.LoginFlow.Results
{
    public class LoginFailed : ILoginResult
    {
        public RpcError FailReason { get; }

        public LoginFailed(RpcError failReason)
        {
            FailReason = failReason;
        }
    }
}