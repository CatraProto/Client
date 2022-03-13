using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class WebAuthorizations : CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase
	{


        public static int StaticConstructorId { get => -313079300; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("authorizations")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase> Authorizations { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public WebAuthorizations (IList<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase> authorizations,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Authorizations = authorizations;
Users = users;
 
}
#nullable disable
        internal WebAuthorizations() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Authorizations);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Authorizations = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "account.webAuthorizations";
		}
	}
}