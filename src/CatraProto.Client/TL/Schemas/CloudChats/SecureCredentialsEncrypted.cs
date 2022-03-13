using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureCredentialsEncrypted : CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase
	{


        public static int StaticConstructorId { get => 871426631; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("data")]
		public sealed override byte[] Data { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public sealed override byte[] Hash { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public sealed override byte[] Secret { get; set; }


        #nullable enable
 public SecureCredentialsEncrypted (byte[] data,byte[] hash,byte[] secret)
{
 Data = data;
Hash = hash;
Secret = secret;
 
}
#nullable disable
        internal SecureCredentialsEncrypted() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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