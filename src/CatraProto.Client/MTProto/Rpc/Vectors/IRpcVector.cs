using System.Collections.Generic;

namespace CatraProto.Client.MTProto.Rpc.Vectors
{
    public interface IRpcVector
    {
        public void Cast(IList<object> obj);
    }
}