using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSet : StickerSetBase
	{
		public static int ConstructorId { get; } = -1240849242;
		public override CloudChats.StickerSetBase Set { get; set; }
		public override IList<StickerPackBase> Packs { get; set; }
		public override IList<DocumentBase> Documents { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Set);
			writer.Write(Packs);
			writer.Write(Documents);
		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<CloudChats.StickerSetBase>();
			Packs = reader.ReadVector<StickerPackBase>();
			Documents = reader.ReadVector<DocumentBase>();
		}
	}
}