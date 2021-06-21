using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Stickers : StickersBase
	{
		public static int ConstructorId { get; } = -463889475;
		public int Hash { get; set; }
		public IList<DocumentBase> Stickers_ { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Stickers_);
		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Stickers_ = reader.ReadVector<DocumentBase>();
		}
	}
}