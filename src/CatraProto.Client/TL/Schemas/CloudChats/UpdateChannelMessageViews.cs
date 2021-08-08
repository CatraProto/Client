using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelMessageViews : UpdateBase
	{


        public static int StaticConstructorId { get => -1734268085; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }

[JsonPropertyName("views")]
		public int Views { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(Id);
			writer.Write(Views);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			Id = reader.Read<int>();
			Views = reader.Read<int>();

		}
	}
}