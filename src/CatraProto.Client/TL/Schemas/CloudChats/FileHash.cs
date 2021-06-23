using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FileHash : FileHashBase
	{
		public static int ConstructorId { get; } = 1648543603;
		public override int Offset { get; set; }
		public override int Limit { get; set; }
		public override byte[] Hash { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Offset);
			writer.Write(Limit);
			writer.Write(Hash);
		}

		public override void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
			Hash = reader.Read<byte[]>();
		}
	}
}