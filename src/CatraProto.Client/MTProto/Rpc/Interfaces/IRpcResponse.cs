namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    internal interface IRpcResponse
    {
        internal void SetResponse(object o, ExecutionInfo executionInfo);
        internal bool CanCast(object o);
    }
}