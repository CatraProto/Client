using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Storage;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class File : FileBase
	{


        public static int StaticConstructorId { get => 157948117; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public FileTypeBase Type { get; set; }

[JsonPropertyName("mtime")]
		public int Mtime { get; set; }

[JsonPropertyName("bytes")]
		public byte[] Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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