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


        public static int StaticConstructorId { get => 1275039392; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("authorization_ttl_days")]
		public override int AuthorizationTtlDays { get; set; }

[Newtonsoft.Json.JsonProperty("authorizations")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase> AuthorizationsField { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}