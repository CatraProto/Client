using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureFile : SecureFileBase
	{


        public static int StaticConstructorId { get => -534283678; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public long Id { get; set; }

[JsonPropertyName("access_hash")]
		public long AccessHash { get; set; }

[JsonPropertyName("size")]
		public int Size { get; set; }

[JsonPropertyName("dc_id")]
		public int DcId { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

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
			writer.Write(AccessHash);
			writer.Write(Size);
			writer.Write(DcId);
			writer.Write(Date);
			writer.Write(FileHash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Size = reader.Read<int>();
			DcId = reader.Read<int>();
			Date = reader.Read<int>();
			FileHash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "secureFile";
		}
	}
}