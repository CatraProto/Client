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


        public static int StaticConstructorId { get => -1652231205; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

[Newtonsoft.Json.JsonProperty("thumb_version")]
		public int ThumbVersion { get; set; }


        #nullable enable
 public InputStickerSetThumb (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset,int thumbVersion)
{
 Stickerset = stickerset;
ThumbVersion = thumbVersion;
 
}
#nullable disable
        internal InputStickerSetThumb() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(ThumbVersion);

		}

		public override void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			ThumbVersion = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "inputStickerSetThumb";
		}
	}
}