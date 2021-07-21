using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSet : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase
	{


        public static int StaticConstructorId { get => -1240849242; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("set")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

[JsonPropertyName("packs")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

[JsonPropertyName("documents")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Packs);
			writer.Write(Documents);

		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
			Packs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>();
			Documents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}