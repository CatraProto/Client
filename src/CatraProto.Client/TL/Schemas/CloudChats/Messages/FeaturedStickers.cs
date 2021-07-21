using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FeaturedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase
	{


        public static int StaticConstructorId { get => -1230257343; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("count")]
		public override int Count { get; set; }

[JsonPropertyName("sets")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }

[JsonPropertyName("unread")]
		public IList<long> Unread { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Count);
			writer.Write(Sets);
			writer.Write(Unread);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Count = reader.Read<int>();
			Sets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();
			Unread = reader.ReadVector<long>();

		}
	}
}