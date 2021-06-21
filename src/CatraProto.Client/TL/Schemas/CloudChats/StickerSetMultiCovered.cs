using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetMultiCovered : StickerSetCoveredBase
	{
		public static int ConstructorId { get; } = 872932635;
		public override StickerSetBase Set { get; set; }
		public IList<DocumentBase> Covers { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Covers);
		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<StickerSetBase>();
			Covers = reader.ReadVector<DocumentBase>();
		}
	}
}