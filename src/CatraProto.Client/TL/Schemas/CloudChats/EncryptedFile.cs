using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedFile : EncryptedFileBase
	{


        public static int StaticConstructorId { get => 1248893260; }
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

[JsonPropertyName("key_fingerprint")]
		public int KeyFingerprint { get; set; }

        
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
			writer.Write(KeyFingerprint);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Size = reader.Read<int>();
			DcId = reader.Read<int>();
			KeyFingerprint = reader.Read<int>();
		}

		public override string ToString()
		{
			return "encryptedFile";
		}
	}
}