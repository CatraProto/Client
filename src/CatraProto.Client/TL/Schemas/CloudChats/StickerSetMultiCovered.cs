using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetMultiCovered : StickerSetCoveredBase
	{


        public static int StaticConstructorId { get => 872932635; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("set")]
		public override StickerSetBase Set { get; set; }

[JsonPropertyName("covers")]
		public IList<DocumentBase> Covers { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Covers);

		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<StickerSetBase>();
			Covers = reader.ReadVector<DocumentBase>();

		}
	}
}