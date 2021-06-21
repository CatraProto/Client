using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class CdnFile : CdnFileBase
	{
		public static int ConstructorId { get; } = -1449145777;
		public byte[] Bytes { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Bytes);
		}

		public override void Deserialize(Reader reader)
		{
			Bytes = reader.Read<byte[]>();
		}
	}
}