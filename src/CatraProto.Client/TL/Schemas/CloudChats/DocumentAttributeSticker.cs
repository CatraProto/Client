using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DocumentAttributeSticker : DocumentAttributeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Mask = 1 << 1,
			MaskCoords = 1 << 0
		}

        public static int StaticConstructorId { get => 1662637586; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("mask")]
		public bool Mask { get; set; }

[JsonPropertyName("alt")]
		public string Alt { get; set; }

[JsonPropertyName("stickerset")]
		public InputStickerSetBase Stickerset { get; set; }

[JsonPropertyName("mask_coords")]
		public MaskCoordsBase MaskCoords { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Mask ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = MaskCoords == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Alt);
			writer.Write(Stickerset);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(MaskCoords);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Mask = FlagsHelper.IsFlagSet(Flags, 1);
			Alt = reader.Read<string>();
			Stickerset = reader.Read<InputStickerSetBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MaskCoords = reader.Read<MaskCoordsBase>();
			}


		}
	}
}