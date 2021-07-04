using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats.Storage;


namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class WebFile : WebFileBase
	{


        public static int ConstructorId { get; } = 568808380;
		public override int Size { get; set; }
		public override string MimeType { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase FileType { get; set; }
		public override int Mtime { get; set; }
		public override byte[] Bytes { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Size);
			writer.Write(MimeType);
			writer.Write(FileType);
			writer.Write(Mtime);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Size = reader.Read<int>();
			MimeType = reader.Read<string>();
			FileType = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase>();
			Mtime = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}