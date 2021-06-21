using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockPhoto : PageBlockBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Url = 1 << 0,
			WebpageId = 1 << 0
		}

		public static int ConstructorId { get; } = 391759200;
		public int Flags { get; set; }
		public long PhotoId { get; set; }
		public PageCaptionBase Caption { get; set; }
		public string Url { get; set; }
		public long? WebpageId { get; set; }

		public override void UpdateFlags()
		{
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = WebpageId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PhotoId);
			writer.Write(Caption);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Url);
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(WebpageId.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			PhotoId = reader.Read<long>();
			Caption = reader.Read<PageCaptionBase>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Url = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				WebpageId = reader.Read<long>();
			}
		}
	}
}