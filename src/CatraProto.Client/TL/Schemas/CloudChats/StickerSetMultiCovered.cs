using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetMultiCovered : CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase
	{


        public static int StaticConstructorId { get => 872932635; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("set")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

[JsonPropertyName("covers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Covers { get; set; }

        
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
			Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
			Covers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}