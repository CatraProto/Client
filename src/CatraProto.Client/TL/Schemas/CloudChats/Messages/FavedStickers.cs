using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FavedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase
	{


        public static int StaticConstructorId { get => 750063767; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("packs")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

[Newtonsoft.Json.JsonProperty("stickers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Stickers { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Packs);
			writer.Write(Stickers);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();
			Packs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>();
			Stickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
				
		public override string ToString()
		{
		    return "messages.favedStickers";
		}
	}
}