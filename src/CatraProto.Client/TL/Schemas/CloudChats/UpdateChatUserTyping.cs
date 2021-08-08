using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatUserTyping : UpdateBase
	{


        public static int StaticConstructorId { get => -1704596961; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat_id")]
		public int ChatId { get; set; }

[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("action")]
		public SendMessageActionBase Action { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			UserId = reader.Read<int>();
			Action = reader.Read<SendMessageActionBase>();

		}
	}
}