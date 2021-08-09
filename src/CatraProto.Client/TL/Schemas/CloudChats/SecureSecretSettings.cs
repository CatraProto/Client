using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureSecretSettings : CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase
	{


        public static int StaticConstructorId { get => 354925740; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("secure_algo")]
		public override CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase SecureAlgo { get; set; }

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
			SecureAlgo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase>();
			SecureSecret = reader.Read<byte[]>();
			SecureSecretId = reader.Read<long>();

		}
	}
}