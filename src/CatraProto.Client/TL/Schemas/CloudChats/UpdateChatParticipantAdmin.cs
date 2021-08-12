using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatParticipantAdmin : UpdateBase
	{


        public static int StaticConstructorId { get => -1232070311; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat_id")]
		public int ChatId { get; set; }

[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("is_admin")]
		public bool IsAdmin { get; set; }

[JsonPropertyName("version")]
		public int Version { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(IsAdmin);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			UserId = reader.Read<int>();
			IsAdmin = reader.Read<bool>();
			Version = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updateChatParticipantAdmin";
		}
	}
}