using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotCommand : BotCommandBase
	{


        public static int StaticConstructorId { get => -1032140601; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("command")]
		public override string Command { get; set; }

[JsonPropertyName("description")]
		public override string Description { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Command);
			writer.Write(Description);

		}

		public override void Deserialize(Reader reader)
		{
			Command = reader.Read<string>();
			Description = reader.Read<string>();
		}

		public override string ToString()
		{
			return "botCommand";
		}
	}
}