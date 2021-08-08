using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChannelMigrateFrom : MessageActionBase
	{


        public static int StaticConstructorId { get => -1336546578; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("chat_id")]
		public int ChatId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Title);
			writer.Write(ChatId);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();
			ChatId = reader.Read<int>();

		}
	}
}