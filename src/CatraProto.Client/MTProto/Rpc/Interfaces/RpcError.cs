namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    public abstract class RpcError
    {
        public abstract int ErrorCode { get; }
        public abstract string ErrorMessage { get; }
        public abstract string ErrorDescription { get; }

        public override string ToString()
        {
            return $"[{ErrorCode}][{ErrorDescription}]";
        }
    }
}