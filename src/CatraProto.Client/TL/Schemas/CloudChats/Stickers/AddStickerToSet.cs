using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class AddStickerToSet : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2041315650; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

[Newtonsoft.Json.JsonProperty("sticker")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase Sticker { get; set; }

        
        #nullable enable
 public AddStickerToSet (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset,CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase sticker)
{
 Stickerset = stickerset;
Sticker = sticker;
 
}
#nullable disable
                
        internal AddStickerToSet() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(Sticker);

		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			Sticker = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase>();

		}

		public override string ToString()
		{
		    return "stickers.addStickerToSet";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}