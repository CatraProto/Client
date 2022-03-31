using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Authorizations : CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1275039392; }
        
[Newtonsoft.Json.JsonProperty("authorization_ttl_days")]
		public sealed override int AuthorizationTtlDays { get; set; }

[Newtonsoft.Json.JsonProperty("authorizations")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase> AuthorizationsField { get; set; }


        #nullable enable
 public Authorizations (int authorizationTtlDays,IList<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase> authorizationsField)
{
 AuthorizationTtlDays = authorizationTtlDays;
AuthorizationsField = authorizationsField;
 
}
#nullable disable
        internal Authorizations() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(AuthorizationTtlDays);
			writer.Write(AuthorizationsField);

		}

		public override void Deserialize(Reader reader)
		{
			AuthorizationTtlDays = reader.Read<int>();
			AuthorizationsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>();

		}
		
		public override string ToString()
		{
		    return "account.authorizations";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}