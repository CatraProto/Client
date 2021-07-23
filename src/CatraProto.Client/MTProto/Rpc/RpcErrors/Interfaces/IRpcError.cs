namespace CatraProto.Client.MTProto.Rpc.RpcErrors.Interfaces
{
    public interface IRpcError
    {
        public int ErrorCode { get; }
        public string ErrorMessage { get; }
        public string ErrorDescription { get; }
    }
}