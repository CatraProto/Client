using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedFile : EncryptedFileBase
	{
		public static int ConstructorId { get; } = 1248893260;
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public int Size { get; set; }
		public int DcId { get; set; }
		public int KeyFingerprint { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Size);
			writer.Write(DcId);
			writer.Write(KeyFingerprint);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Size = reader.Read<int>();
			DcId = reader.Read<int>();
			KeyFingerprint = reader.Read<int>();
		}
	}
}