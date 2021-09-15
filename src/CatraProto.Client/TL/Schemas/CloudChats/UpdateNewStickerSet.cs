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


        public static int StaticConstructorId { get => 1753886890; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase Stickerset { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}