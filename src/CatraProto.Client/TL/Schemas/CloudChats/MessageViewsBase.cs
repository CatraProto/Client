using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageViewsBase : IObject
    {
		public abstract int? Views { get; set; }
		public abstract int? Forwards { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase Replies { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
