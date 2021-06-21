using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserProfilePhoto : UserProfilePhotoBase
	{
		[Flags]
		public enum FlagsEnum
		{
			HasVideo = 1 << 0
		}

		public static int ConstructorId { get; } = 1775479590;
		public int Flags { get; set; }
		public bool HasVideo { get; set; }
		public long PhotoId { get; set; }
		public FileLocationBase PhotoSmall { get; set; }
		public FileLocationBase PhotoBig { get; set; }
		public int DcId { get; set; }

		public override void UpdateFlags()
		{
			Flags = HasVideo ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoId);
			writer.Write(PhotoSmall);
			writer.Write(PhotoBig);
			writer.Write(DcId);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasVideo = FlagsHelper.IsFlagSet(Flags, 0);
			PhotoId = reader.Read<long>();
			PhotoSmall = reader.Read<FileLocationBase>();
			PhotoBig = reader.Read<FileLocationBase>();
			DcId = reader.Read<int>();
		}
	}
}