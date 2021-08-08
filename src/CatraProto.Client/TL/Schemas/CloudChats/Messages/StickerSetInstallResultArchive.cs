using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSetInstallResultArchive : StickerSetInstallResultBase
	{


        public static int StaticConstructorId { get => 904138920; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("sets")]
		public IList<StickerSetCoveredBase> Sets { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Sets);

		}

		public override void Deserialize(Reader reader)
		{
			Sets = reader.ReadVector<StickerSetCoveredBase>();

		}
	}
}