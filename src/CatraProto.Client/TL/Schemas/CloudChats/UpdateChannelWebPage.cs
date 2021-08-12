using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelWebPage : UpdateBase
	{


        public static int StaticConstructorId { get => 1081547008; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

[JsonPropertyName("webpage")]
		public WebPageBase Webpage { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public int PtsCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(Webpage);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			Webpage = reader.Read<WebPageBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updateChannelWebPage";
		}
	}
}