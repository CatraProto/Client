using CatraProto.Client.Connections;

namespace CatraProto.Client.MTProto.Rpc
{
    public class ExecutionInfo
    {
        public ConnectionInfo ExecutedBy { get; }
        public ExecutionInfo(ConnectionInfo executedBy)
        {
            ExecutedBy = executedBy;
        }
    }
}