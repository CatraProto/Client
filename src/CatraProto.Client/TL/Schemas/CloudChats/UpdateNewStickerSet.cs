using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewStickerSet : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1753886890; }
        
[Newtonsoft.Json.JsonProperty("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase Stickerset { get; set; }


        #nullable enable
 public UpdateNewStickerSet (CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase stickerset)
{
 Stickerset = stickerset;
 
}
#nullable disable
        internal UpdateNewStickerSet() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Stickerset);

		}

		public override void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();

		}
		
		public override string ToString()
		{
		    return "updateNewStickerSet";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}