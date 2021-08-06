using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetCovered : CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase
	{


        public static int StaticConstructorId { get => 1678812626; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("set")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

[JsonPropertyName("cover")]
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Cover { get; set; }

        
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
			Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
			Cover = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}