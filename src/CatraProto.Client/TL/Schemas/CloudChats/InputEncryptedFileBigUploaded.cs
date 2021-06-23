using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedFileBigUploaded : InputEncryptedFileBase
	{
		public static int ConstructorId { get; } = 767652808;
		public long Id { get; set; }
		public int Parts { get; set; }
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
			writer.Write(Parts);
			writer.Write(KeyFingerprint);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			KeyFingerprint = reader.Read<int>();
		}
	}
}