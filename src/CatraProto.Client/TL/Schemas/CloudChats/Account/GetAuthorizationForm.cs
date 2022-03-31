using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAuthorizationForm : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1456907910; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("bot_id")]
		public long BotId { get; set; }

[Newtonsoft.Json.JsonProperty("scope")]
		public string Scope { get; set; }

[Newtonsoft.Json.JsonProperty("public_key")]
		public string PublicKey { get; set; }

        
        #nullable enable
 public GetAuthorizationForm (long botId,string scope,string publicKey)
{
 BotId = botId;
Scope = scope;
PublicKey = publicKey;
 
}
#nullable disable
                
        internal GetAuthorizationForm() 
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

		}

		public void Deserialize(Reader reader)
		{
			BotId = reader.Read<long>();
			Scope = reader.Read<string>();
			PublicKey = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "account.getAuthorizationForm";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}