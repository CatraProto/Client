using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockVideo : PageBlockBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Autoplay = 1 << 0,
			Loop = 1 << 1
		}

        public static int ConstructorId { get; } = 2089805750;
		public int Flags { get; set; }
		public bool Autoplay { get; set; }
		public bool Loop { get; set; }
		public long VideoId { get; set; }
		public PageCaptionBase Caption { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Autoplay ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Loop ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(VideoId);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Autoplay = FlagsHelper.IsFlagSet(Flags, 0);
			Loop = FlagsHelper.IsFlagSet(Flags, 1);
			VideoId = reader.Read<long>();
			Caption = reader.Read<PageCaptionBase>();

		}
	}
}