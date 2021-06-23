using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class CreateStickerSet : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Masks = 1 << 0,
			Animated = 1 << 1,
			Thumb = 1 << 2
		}

		public static int ConstructorId { get; } = -251435136;
		public int Flags { get; set; }
		public bool Masks { get; set; }
		public bool Animated { get; set; }
		public InputUserBase UserId { get; set; }
		public string Title { get; set; }
		public string ShortName { get; set; }
		public InputDocumentBase Thumb { get; set; }
		public IList<InputStickerSetItemBase> Stickers { get; set; }

		public Type Type { get; init; } = typeof(Messages.StickerSetBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Animated ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(Title);
			writer.Write(ShortName);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Thumb);
			}

			writer.Write(Stickers);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Masks = FlagsHelper.IsFlagSet(Flags, 0);
			Animated = FlagsHelper.IsFlagSet(Flags, 1);
			UserId = reader.Read<InputUserBase>();
			Title = reader.Read<string>();
			ShortName = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				Thumb = reader.Read<InputDocumentBase>();
			}

			Stickers = reader.ReadVector<InputStickerSetItemBase>();
		}
	}
}