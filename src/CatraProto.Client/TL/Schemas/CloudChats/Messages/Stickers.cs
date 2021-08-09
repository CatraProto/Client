using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Stickers : StickersBase
	{


        public static int StaticConstructorId { get => -463889475; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("Stickers_")] public IList<DocumentBase> Stickers_ { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Stickers_);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Stickers_ = reader.ReadVector<DocumentBase>();

		}
	}
}