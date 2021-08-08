using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureSecretSettings : SecureSecretSettingsBase
	{


        public static int StaticConstructorId { get => 354925740; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("secure_algo")]
		public override SecurePasswordKdfAlgoBase SecureAlgo { get; set; }

[JsonPropertyName("secure_secret")]
		public override byte[] SecureSecret { get; set; }

[JsonPropertyName("secure_secret_id")]
		public override long SecureSecretId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(SecureAlgo);
			writer.Write(SecureSecret);
			writer.Write(SecureSecretId);

		}

		public override void Deserialize(Reader reader)
		{
			SecureAlgo = reader.Read<SecurePasswordKdfAlgoBase>();
			SecureSecret = reader.Read<byte[]>();
			SecureSecretId = reader.Read<long>();

		}
	}
}