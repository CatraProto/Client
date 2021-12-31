using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FeaturedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase
	{


        public static int StaticConstructorId { get => -2067782896; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("sets")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }

[Newtonsoft.Json.JsonProperty("unread")]
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
			Hash = reader.Read<long>();
			Count = reader.Read<int>();
			Sets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();
			Unread = reader.ReadVector<long>();

		}
				
		public override string ToString()
		{
		    return "messages.featuredStickers";
		}
	}
}