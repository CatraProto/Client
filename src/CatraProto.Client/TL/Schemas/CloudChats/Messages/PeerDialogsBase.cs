using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class PeerDialogsBase : IObject
    {

[JsonPropertyName("dialogs")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> Dialogs { get; set; }

[JsonPropertyName("messages")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[JsonPropertyName("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[JsonPropertyName("state")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase State { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
