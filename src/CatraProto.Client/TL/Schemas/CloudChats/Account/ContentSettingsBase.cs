using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class ContentSettingsBase : IObject
    {
        public abstract bool SensitiveEnabled { get; set; }
        public abstract bool SensitiveCanChange { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}