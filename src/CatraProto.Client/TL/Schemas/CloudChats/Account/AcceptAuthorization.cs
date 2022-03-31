using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AcceptAuthorization : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -202552205; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("bot_id")]
		public long BotId { get; set; }

[Newtonsoft.Json.JsonProperty("scope")]
		public string Scope { get; set; }

[Newtonsoft.Json.JsonProperty("public_key")]
		public string PublicKey { get; set; }

[Newtonsoft.Json.JsonProperty("value_hashes")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> ValueHashes { get; set; }

[Newtonsoft.Json.JsonProperty("credentials")]
		public CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase Credentials { get; set; }

        
        #nullable enable
 public AcceptAuthorization (long botId,string scope,string publicKey,IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> valueHashes,CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials)
{
 BotId = botId;
Scope = scope;
PublicKey = publicKey;
ValueHashes = valueHashes;
Credentials = credentials;
 
}
#nullable disable
                
        internal AcceptAuthorization() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(Scope);
			writer.Write(PublicKey);
			writer.Write(ValueHashes);
			writer.Write(Credentials);

		}

		public void Deserialize(Reader reader)
		{
			BotId = reader.Read<long>();
			Scope = reader.Read<string>();
			PublicKey = reader.Read<string>();
			ValueHashes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase>();
			Credentials = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase>();

		}

		public override string ToString()
		{
		    return "account.acceptAuthorization";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}