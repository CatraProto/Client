using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSizeProgressive : PhotoSizeBase
	{
		public static int ConstructorId { get; } = 1520986705;
		public override string Type { get; set; }
		public FileLocationBase Location { get; set; }
		public int W { get; set; }
		public int H { get; set; }
		public IList<int> Sizes { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Type);
			writer.Write(Location);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Sizes);
		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			Location = reader.Read<FileLocationBase>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Sizes = reader.ReadVector<int>();
		}
	}
}