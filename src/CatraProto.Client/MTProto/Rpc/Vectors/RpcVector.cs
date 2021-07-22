using System.Collections.Generic;

namespace CatraProto.Client.MTProto.Rpc.Vectors
{
    public class RpcVector<T> : List<T>, IRpcVector
    {
        public void Cast(IList<object> list)
        {
            foreach (T o in list)
            {
                Add(o);
            }
        }
    }
}