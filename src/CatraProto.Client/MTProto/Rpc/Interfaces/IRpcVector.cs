using System.Collections.Generic;

namespace CatraProto.Client.MTProto.Rpc.Interfaces
{
    public interface IRpcVector
    {
        public void Cast(IEnumerable<object> obj);
    }
}