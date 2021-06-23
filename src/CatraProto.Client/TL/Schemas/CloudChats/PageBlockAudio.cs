using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockAudio : PageBlockBase
	{
		public static int ConstructorId { get; } = -2143067670;
		public long AudioId { get; set; }
		public PageCaptionBase Caption { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(AudioId);
			writer.Write(Caption);
		}

		public override void Deserialize(Reader reader)
		{
			AudioId = reader.Read<long>();
			Caption = reader.Read<PageCaptionBase>();
		}
	}
}