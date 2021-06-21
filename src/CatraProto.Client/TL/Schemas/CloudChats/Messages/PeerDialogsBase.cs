using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class PeerDialogsBase : IObject
    {
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> Dialogs { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase State { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
