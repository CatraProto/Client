using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetAuthorizationTTL : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1081501024; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("authorization_ttl_days")]
		public int AuthorizationTtlDays { get; set; }

        
        #nullable enable
 public SetAuthorizationTTL (int authorizationTtlDays)
{
 AuthorizationTtlDays = authorizationTtlDays;
 
}
#nullable disable
                
        internal SetAuthorizationTTL() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(AuthorizationTtlDays);

		}

		public void Deserialize(Reader reader)
		{
			AuthorizationTtlDays = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "account.setAuthorizationTTL";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}