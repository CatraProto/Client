using System.Collections.Generic;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.Vectors
{
    public class RpcVector<T> : List<T>, IRpcVector
    {
        public RpcVector()
        {

        }
        public RpcVector(int capacity) : base(capacity)
        {

        }

        public RpcVector(IEnumerable<T> initial) : base(initial)
        {

        }

        public void Cast(IEnumerable<object> list)
        {
            foreach (T o in list)
            {
                Add(o);
            }
        }
    }
}