using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class ChatFullBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase FullChat { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
