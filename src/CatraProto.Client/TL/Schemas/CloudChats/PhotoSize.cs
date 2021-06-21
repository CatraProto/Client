using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSize : PhotoSizeBase
	{
		public static int ConstructorId { get; } = 2009052699;
		public override string Type { get; set; }
		public FileLocationBase Location { get; set; }
		public int W { get; set; }
		public int H { get; set; }
		public int Size { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Location);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Size);
		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			Location = reader.Read<FileLocationBase>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Size = reader.Read<int>();
		}
	}
}