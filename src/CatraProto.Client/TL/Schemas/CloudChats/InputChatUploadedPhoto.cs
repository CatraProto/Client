using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChatUploadedPhoto : InputChatPhotoBase
	{
		[Flags]
		public enum FlagsEnum
		{
			File = 1 << 0,
			Video = 1 << 1,
			VideoStartTs = 1 << 2
		}

		public static int ConstructorId { get; } = -968723890;
		public int Flags { get; set; }
		public InputFileBase File { get; set; }
		public InputFileBase Video { get; set; }
		public double? VideoStartTs { get; set; }

		public override void UpdateFlags()
		{
			Flags = File == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Video == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(File);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Video);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(VideoStartTs);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				File = reader.Read<InputFileBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				Video = reader.Read<InputFileBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				VideoStartTs = reader.Read<double>();
			}
		}
	}
}