using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSet : StickerSetBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Archived = 1 << 1,
			Official = 1 << 2,
			Masks = 1 << 3,
			Animated = 1 << 5,
			InstalledDate = 1 << 0,
			Thumb = 1 << 4,
			ThumbDcId = 1 << 4
		}

        public static int ConstructorId { get; } = -290164953;
		public int Flags { get; set; }
		public override bool Archived { get; set; }
		public override bool Official { get; set; }
		public override bool Masks { get; set; }
		public override bool Animated { get; set; }
		public override int? InstalledDate { get; set; }
		public override long Id { get; set; }
		public override long AccessHash { get; set; }
		public override string Title { get; set; }
		public override string ShortName { get; set; }
		public override PhotoSizeBase Thumb { get; set; }
		public override int? ThumbDcId { get; set; }
		public override int Count { get; set; }
		public override int Hash { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Archived ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Official ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Animated ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = InstalledDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = ThumbDcId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(InstalledDate.Value);
			}

			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Title);
			writer.Write(ShortName);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Thumb);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(ThumbDcId.Value);
			}

			writer.Write(Count);
			writer.Write(Hash);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Archived = FlagsHelper.IsFlagSet(Flags, 1);
			Official = FlagsHelper.IsFlagSet(Flags, 2);
			Masks = FlagsHelper.IsFlagSet(Flags, 3);
			Animated = FlagsHelper.IsFlagSet(Flags, 5);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				InstalledDate = reader.Read<int>();
			}

			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Title = reader.Read<string>();
			ShortName = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Thumb = reader.Read<PhotoSizeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				ThumbDcId = reader.Read<int>();
			}

			Count = reader.Read<int>();
			Hash = reader.Read<int>();

		}
	}
}