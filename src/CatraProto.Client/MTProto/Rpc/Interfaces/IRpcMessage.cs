namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    interface IRpcMessage
    {
        internal void SetResponse(object o, ExecutionInfo executionInfo);
    }
}