using System.Collections.Generic;

namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    public interface IRpcVector
    {
        public void Cast(IList<object> obj);
    }
}