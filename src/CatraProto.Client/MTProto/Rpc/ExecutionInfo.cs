using CatraProto.Client.Connections;

namespace CatraProto.Client.MTProto.Rpc
{
    public class ExecutionInfo
    {
        public ConnectionInfo ExecutedBy { get; }
        public bool IsTelegramRpc { get; }
        public ExecutionInfo(ConnectionInfo executedBy, bool isTelegramRpc = false)
        {
            IsTelegramRpc = isTelegramRpc;
            ExecutedBy = executedBy;
        }
    }
}