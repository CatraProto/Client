using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputBotInlineMessageIDBase : IObject
    {
        public abstract int DcId { get; set; }
        public abstract long Id { get; set; }
        public abstract long AccessHash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}