using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FavedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase
	{


        public static int StaticConstructorId { get => -209768682; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("packs")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

[JsonPropertyName("stickers")]
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
			Hash = reader.Read<int>();
			Packs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>();
			Stickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}