using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDocumentFileLocation : InputFileLocationBase
	{
		public static int ConstructorId { get; } = -1160743548;
		public long Id { get; set; }
		public long AccessHash { get; set; }
		public byte[] FileReference { get; set; }
		public string ThumbSize { get; set; }

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
			writer.Write(FileReference);
			writer.Write(ThumbSize);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();
			ThumbSize = reader.Read<string>();
		}
	}
}