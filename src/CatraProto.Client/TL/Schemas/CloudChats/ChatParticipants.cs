using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatParticipants : ChatParticipantsBase
	{


        public static int StaticConstructorId { get => 1061556205; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat_id")]
		public override int ChatId { get; set; }

[JsonPropertyName("participants")]
		public IList<ChatParticipantBase> Participants { get; set; }

[JsonPropertyName("version")]
		public int Version { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(Participants);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			Participants = reader.ReadVector<ChatParticipantBase>();
			Version = reader.Read<int>();

		}
	}
}