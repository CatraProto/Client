using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSet : StickerSetBase
	{


        public static int StaticConstructorId { get => -1240849242; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("set")] public override CloudChats.StickerSetBase Set { get; set; }

[JsonPropertyName("packs")] public override IList<StickerPackBase> Packs { get; set; }

[JsonPropertyName("documents")] public override IList<DocumentBase> Documents { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Packs);
			writer.Write(Documents);

		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<CloudChats.StickerSetBase>();
			Packs = reader.ReadVector<StickerPackBase>();
			Documents = reader.ReadVector<DocumentBase>();

		}
	}
}