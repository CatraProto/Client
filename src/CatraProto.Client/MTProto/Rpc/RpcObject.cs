using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcObject : IObject
    {
        public long MessageId { get; set; }
        public object Response { get; set; }
        public void Deserialize(Reader reader)
        {
            throw new NotImplementedException();
        }

        public void Serialize(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFlags()
        {
            throw new System.NotImplementedException();
        }
    }
}