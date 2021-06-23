using CatraProto.Client.TL.Schemas.CloudChats.Storage;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class File : FileBase
	{
		public static int ConstructorId { get; } = 157948117;
		public FileTypeBase Type { get; set; }
		public int Mtime { get; set; }
		public byte[] Bytes { get; set; }

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
			writer.Write(Mtime);
			writer.Write(Bytes);
		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<FileTypeBase>();
			Mtime = reader.Read<int>();
			Bytes = reader.Read<byte[]>();
		}
	}
}