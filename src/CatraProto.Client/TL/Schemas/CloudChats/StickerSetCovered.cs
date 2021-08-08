using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetCovered : StickerSetCoveredBase
	{


        public static int StaticConstructorId { get => 1678812626; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("set")]
		public override StickerSetBase Set { get; set; }

[JsonPropertyName("cover")]
		public DocumentBase Cover { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Cover);

		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<StickerSetBase>();
			Cover = reader.Read<DocumentBase>();

		}
	}
}