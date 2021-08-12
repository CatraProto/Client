using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class RecentStickers : RecentStickersBase
	{


        public static int StaticConstructorId { get => 586395571; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

		[JsonPropertyName("packs")] public IList<StickerPackBase> Packs { get; set; }

		[JsonPropertyName("stickers")] public IList<DocumentBase> Stickers { get; set; }

[JsonPropertyName("dates")]
		public IList<int> Dates { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Packs);
			writer.Write(Stickers);
			writer.Write(Dates);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Packs = reader.ReadVector<StickerPackBase>();
			Stickers = reader.ReadVector<DocumentBase>();
			Dates = reader.ReadVector<int>();
		}

		public override string ToString()
		{
			return "messages.recentStickers";
		}
	}
}