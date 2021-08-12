using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureCredentialsEncrypted : SecureCredentialsEncryptedBase
	{


        public static int StaticConstructorId { get => 871426631; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("data")]
		public override byte[] Data { get; set; }

[JsonPropertyName("hash")]
		public override byte[] Hash { get; set; }

[JsonPropertyName("secret")]
		public override byte[] Secret { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Data);
			writer.Write(Hash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Data = reader.Read<byte[]>();
			Hash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "secureCredentialsEncrypted";
		}
	}
}