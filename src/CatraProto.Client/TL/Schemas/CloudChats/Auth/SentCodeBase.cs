using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class SentCodeBase : IObject
    {
        public abstract SentCodeTypeBase Type { get; set; }
        public abstract string PhoneCodeHash { get; set; }
        public abstract CodeTypeBase NextType { get; set; }
        public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}