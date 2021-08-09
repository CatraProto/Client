using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AllStickers : AllStickersBase
	{


        public static int StaticConstructorId { get => -302170017; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("sets")] public IList<CloudChats.StickerSetBase> Sets { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Sets);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Sets = reader.ReadVector<CloudChats.StickerSetBase>();

		}
	}
}