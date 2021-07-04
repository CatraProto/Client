using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


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

        public static int ConstructorId { get; } = 1662637586;
		public int Flags { get; set; }
		public bool Mask { get; set; }
		public string Alt { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }

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
			Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MaskCoords = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase>();
			}


		}
	}
}