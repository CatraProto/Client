namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
     abstract class RpcErrorParser 
     {
        protected int MinimumLength { get; }
        public abstract RpcError? GetError(TL.Schemas.MTProto.RpcError error);
        
        protected RpcErrorParser(int minimumLength)
        {
            MinimumLength = minimumLength;
        }

        protected bool CheckPrerequisites(string error)
        {
            return error.Length >= MinimumLength;
        }
    }
}