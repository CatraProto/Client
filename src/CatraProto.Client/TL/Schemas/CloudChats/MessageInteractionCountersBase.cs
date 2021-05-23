using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageInteractionCountersBase : IObject
    {
		public abstract int MsgId { get; set; }
		public abstract int Views { get; set; }
		public abstract int Forwards { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
