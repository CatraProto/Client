using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlStickerSet : RecentMeUrlBase
	{


        public static int StaticConstructorId { get => -1140172836; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("url")]
		public override string Url { get; set; }

[JsonPropertyName("set")]
		public StickerSetCoveredBase Set { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(Set);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Set = reader.Read<StickerSetCoveredBase>();
		}

		public override string ToString()
		{
			return "recentMeUrlStickerSet";
		}
	}
}