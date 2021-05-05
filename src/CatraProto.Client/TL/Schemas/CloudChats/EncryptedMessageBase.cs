using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EncryptedMessageBase : IObject
    {
        public abstract long RandomId { get; set; }
        public abstract int ChatId { get; set; }
        public abstract int Date { get; set; }
        public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}