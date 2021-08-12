using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserTyping : UpdateBase
	{


        public static int StaticConstructorId { get => 1548249383; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
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
			writer.Write(UserId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Action = reader.Read<SendMessageActionBase>();
		}

		public override string ToString()
		{
			return "updateUserTyping";
		}
	}
}