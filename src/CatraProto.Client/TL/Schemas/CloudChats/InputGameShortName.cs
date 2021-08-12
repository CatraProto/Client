using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputGameShortName : InputGameBase
	{


        public static int StaticConstructorId { get => -1020139510; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("bot_id")]
		public InputUserBase BotId { get; set; }

[JsonPropertyName("short_name")]
		public string ShortName { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(ShortName);

		}

		public override void Deserialize(Reader reader)
		{
			BotId = reader.Read<InputUserBase>();
			ShortName = reader.Read<string>();
		}

		public override string ToString()
		{
			return "inputGameShortName";
		}
	}
}