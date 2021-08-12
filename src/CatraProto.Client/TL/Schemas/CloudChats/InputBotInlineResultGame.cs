using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultGame : InputBotInlineResultBase
	{


        public static int StaticConstructorId { get => 1336154098; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override string Id { get; set; }

[JsonPropertyName("short_name")]
		public string ShortName { get; set; }

[JsonPropertyName("send_message")]
		public override InputBotInlineMessageBase SendMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(ShortName);
			writer.Write(SendMessage);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			ShortName = reader.Read<string>();
			SendMessage = reader.Read<InputBotInlineMessageBase>();
		}

		public override string ToString()
		{
			return "inputBotInlineResultGame";
		}
	}
}