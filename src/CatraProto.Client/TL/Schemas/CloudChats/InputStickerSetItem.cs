using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetItem : InputStickerSetItemBase
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
		public override InputDocumentBase Document { get; set; }

[JsonPropertyName("emoji")]
		public override string Emoji { get; set; }

[JsonPropertyName("mask_coords")]
		public override MaskCoordsBase MaskCoords { get; set; }

        
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
			Document = reader.Read<InputDocumentBase>();
			Emoji = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MaskCoords = reader.Read<MaskCoordsBase>();
			}
		}

		public override string ToString()
		{
			return "inputStickerSetItem";
		}
	}
}