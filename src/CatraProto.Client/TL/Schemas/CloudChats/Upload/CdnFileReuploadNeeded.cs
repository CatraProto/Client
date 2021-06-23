using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class CdnFileReuploadNeeded : CdnFileBase
	{
		public static int ConstructorId { get; } = -290921362;
		public byte[] RequestToken { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(RequestToken);
		}

		public override void Deserialize(Reader reader)
		{
			RequestToken = reader.Read<byte[]>();
		}
	}
}