using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BotInlineResultBase : IObject
    {
		public abstract string Id { get; set; }
		public abstract string Type { get; set; }
		public abstract string Title { get; set; }
		public abstract string Description { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
