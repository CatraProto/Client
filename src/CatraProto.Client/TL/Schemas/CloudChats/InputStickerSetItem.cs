using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetItem : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			MaskCoords = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -6249322; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("document")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

[Newtonsoft.Json.JsonProperty("emoji")]
		public sealed override string Emoji { get; set; }

[Newtonsoft.Json.JsonProperty("mask_coords")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }


        #nullable enable
 public InputStickerSetItem (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase document,string emoji)
{
 Document = document;
Emoji = emoji;
 
}
#nullable disable
        internal InputStickerSetItem() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = MaskCoords == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Document);
			writer.Write(Emoji);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(MaskCoords);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			Emoji = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MaskCoords = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase>();
			}


		}
		
		public override string ToString()
		{
		    return "inputStickerSetItem";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}