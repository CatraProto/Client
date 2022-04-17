using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class WebAuthorizations : CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -313079300; }
        
[Newtonsoft.Json.JsonProperty("authorizations")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase> Authorizations { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public WebAuthorizations (List<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase> authorizations,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkauthorizations = 			writer.WriteVector(Authorizations, false);
if(checkauthorizations.IsError){
 return checkauthorizations; 
}
var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryauthorizations = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryauthorizations.IsError){
return ReadResult<IObject>.Move(tryauthorizations);
}
Authorizations = tryauthorizations.Value;
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "account.webAuthorizations";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}