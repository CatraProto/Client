using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

        public static int StaticConstructorId { get => -6249322; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("document")]
		public override CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

[JsonPropertyName("emoji")]
		public override string Emoji { get; set; }

[JsonPropertyName("mask_coords")]
		public override CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = MaskCoords == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}