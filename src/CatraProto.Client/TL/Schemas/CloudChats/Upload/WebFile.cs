using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Storage;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class WebFile : WebFileBase
	{


        public static int StaticConstructorId { get => 568808380; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("size")]
		public override int Size { get; set; }

[JsonPropertyName("mime_type")]
		public override string MimeType { get; set; }

[JsonPropertyName("file_type")]
		public override FileTypeBase FileType { get; set; }

[JsonPropertyName("mtime")]
		public override int Mtime { get; set; }

[JsonPropertyName("bytes")]
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
			FileType = reader.Read<FileTypeBase>();
			Mtime = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}