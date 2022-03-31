using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureSecretSettings : CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 354925740; }
        
[Newtonsoft.Json.JsonProperty("secure_algo")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase SecureAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("secure_secret")]
		public sealed override byte[] SecureSecret { get; set; }

[Newtonsoft.Json.JsonProperty("secure_secret_id")]
		public sealed override long SecureSecretId { get; set; }


        #nullable enable
 public SecureSecretSettings (CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase secureAlgo,byte[] secureSecret,long secureSecretId)
{
 SecureAlgo = secureAlgo;
SecureSecret = secureSecret;
SecureSecretId = secureSecretId;
 
}
#nullable disable
        internal SecureSecretSettings() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		
		public override string ToString()
		{
		    return "secureSecretSettings";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}