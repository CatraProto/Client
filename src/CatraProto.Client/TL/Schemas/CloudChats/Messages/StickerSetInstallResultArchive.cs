using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSetInstallResultArchive : StickerSetInstallResultBase
	{
		public static int ConstructorId { get; } = 904138920;
		public IList<StickerSetCoveredBase> Sets { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Sets);
		}

		public override void Deserialize(Reader reader)
		{
			Sets = reader.ReadVector<StickerSetCoveredBase>();
		}
	}
}