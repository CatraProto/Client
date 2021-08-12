using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultPhoto : InputBotInlineResultBase
	{


        public static int StaticConstructorId { get => -1462213465; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override string Id { get; set; }

[JsonPropertyName("type")]
		public string Type { get; set; }

[JsonPropertyName("photo")]
		public InputPhotoBase Photo { get; set; }

[JsonPropertyName("send_message")]
		public override InputBotInlineMessageBase SendMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Type);
			writer.Write(Photo);
			writer.Write(SendMessage);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Type = reader.Read<string>();
			Photo = reader.Read<InputPhotoBase>();
			SendMessage = reader.Read<InputBotInlineMessageBase>();
		}

		public override string ToString()
		{
			return "inputBotInlineResultPhoto";
		}
	}
}