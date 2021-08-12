using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputSecureFileUploaded : InputSecureFileBase
	{


        public static int StaticConstructorId { get => 859091184; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("parts")]
		public int Parts { get; set; }

[JsonPropertyName("md5_checksum")]
		public string Md5Checksum { get; set; }

[JsonPropertyName("file_hash")]
		public byte[] FileHash { get; set; }

[JsonPropertyName("secret")]
		public byte[] Secret { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Parts);
			writer.Write(Md5Checksum);
			writer.Write(FileHash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			Md5Checksum = reader.Read<string>();
			FileHash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "inputSecureFileUploaded";
		}
	}
}