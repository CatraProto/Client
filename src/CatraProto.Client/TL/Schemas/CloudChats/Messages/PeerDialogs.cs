using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class PeerDialogs : CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase
	{


        public static int StaticConstructorId { get => 863093588; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("dialogs")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> Dialogs { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("state")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase State { get; set; }


        #nullable enable
 public PeerDialogs (IList<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> dialogs,IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users,CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase state)
{
 Dialogs = dialogs;
Messages = messages;
Chats = chats;
Users = users;
State = state;
 
}
#nullable disable
        internal PeerDialogs() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Dialogs);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);
			writer.Write(State);

		}

		public override void Deserialize(Reader reader)
		{
			Dialogs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>();
			Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			State = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();

		}
				
		public override string ToString()
		{
		    return "messages.peerDialogs";
		}
	}
}