using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetThumb : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{


        public static int StaticConstructorId { get => 230353641; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

[Newtonsoft.Json.JsonProperty("volume_id")]
		public long VolumeId { get; set; }

[Newtonsoft.Json.JsonProperty("local_id")]
		public int LocalId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(VolumeId);
			writer.Write(LocalId);

		}

		public override void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			VolumeId = reader.Read<long>();
			LocalId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "inputStickerSetThumb";
		}
	}
}