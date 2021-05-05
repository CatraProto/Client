using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class PeerDialogsBase : IObject
    {
		public abstract IList<DialogBase> Dialogs { get; set; }
		public abstract IList<MessageBase> Messages { get; set; }
		public abstract IList<ChatBase> Chats { get; set; }
		public abstract IList<UserBase> Users { get; set; }
		public abstract StateBase State { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
