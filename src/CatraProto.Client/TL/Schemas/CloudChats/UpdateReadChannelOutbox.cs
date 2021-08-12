using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadChannelOutbox : UpdateBase
	{


        public static int StaticConstructorId { get => 634833351; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

[JsonPropertyName("max_id")]
		public int MaxId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(MaxId);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			MaxId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updateReadChannelOutbox";
		}
	}
}