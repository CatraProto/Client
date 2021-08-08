using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class Difference : DifferenceBase
	{


        public static int StaticConstructorId { get => 16030880; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("new_messages")]
		public IList<MessageBase> NewMessages { get; set; }

[JsonPropertyName("new_encrypted_messages")]
		public IList<EncryptedMessageBase> NewEncryptedMessages { get; set; }

[JsonPropertyName("other_updates")]
		public IList<UpdateBase> OtherUpdates { get; set; }

[JsonPropertyName("chats")]
		public IList<ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public IList<UserBase> Users { get; set; }

[JsonPropertyName("state")]
		public StateBase State { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(NewMessages);
			writer.Write(NewEncryptedMessages);
			writer.Write(OtherUpdates);
			writer.Write(Chats);
			writer.Write(Users);
			writer.Write(State);

		}

		public override void Deserialize(Reader reader)
		{
			NewMessages = reader.ReadVector<MessageBase>();
			NewEncryptedMessages = reader.ReadVector<EncryptedMessageBase>();
			OtherUpdates = reader.ReadVector<UpdateBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
			State = reader.Read<StateBase>();

		}
	}
}