using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ArchivedStickers : ArchivedStickersBase
	{


        public static int StaticConstructorId { get => 1338747336; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("count")]
		public override int Count { get; set; }

[JsonPropertyName("sets")] public override IList<StickerSetCoveredBase> Sets { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Sets);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Sets = reader.ReadVector<StickerSetCoveredBase>();

		}
	}
}