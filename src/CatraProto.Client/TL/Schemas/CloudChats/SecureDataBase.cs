using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureDataBase : IObject
    {
        public abstract byte[] Data { get; set; }
        public abstract byte[] DataHash { get; set; }
        public abstract byte[] Secret { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}