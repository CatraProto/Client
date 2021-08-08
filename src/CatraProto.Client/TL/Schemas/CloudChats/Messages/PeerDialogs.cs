using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class PeerDialogs : PeerDialogsBase
	{


        public static int StaticConstructorId { get => 863093588; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("dialogs")]
		public override IList<DialogBase> Dialogs { get; set; }

[JsonPropertyName("messages")]
		public override IList<MessageBase> Messages { get; set; }

[JsonPropertyName("chats")]
		public override IList<ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public override IList<UserBase> Users { get; set; }

[JsonPropertyName("state")]
		public override StateBase State { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Dialogs);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);
			writer.Write(State);

		}

		public override void Deserialize(Reader reader)
		{
			Dialogs = reader.ReadVector<DialogBase>();
			Messages = reader.ReadVector<MessageBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
			State = reader.Read<StateBase>();

		}
	}
}