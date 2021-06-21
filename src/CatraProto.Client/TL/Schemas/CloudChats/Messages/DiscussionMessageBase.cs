using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class DiscussionMessageBase : IObject
    {
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }
		public abstract int? MaxId { get; set; }
		public abstract int? ReadInboxMaxId { get; set; }
		public abstract int? ReadOutboxMaxId { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
