namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    interface IRpcResponse
    {
        internal void SetResponse(object o, ExecutionInfo executionInfo);
        internal bool CanCast(object o);
    }
}