using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Rpc
{
    public class RpcObject : IObject
    {
        public long MessageId { get; set; }
        public void Deserialize(Reader reader)
        {
            MessageId = reader.Read<long>();
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