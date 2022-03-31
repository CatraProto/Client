using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class LoginTokenSuccess : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 957176926; }
        
[Newtonsoft.Json.JsonProperty("authorization")]
		public CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase Authorization { get; set; }


        #nullable enable
 public LoginTokenSuccess (CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase authorization)
{
 Authorization = authorization;
 
}
#nullable disable
        internal LoginTokenSuccess() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Authorization);

		}

		public override void Deserialize(Reader reader)
		{
			Authorization = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();

		}
		
		public override string ToString()
		{
		    return "auth.loginTokenSuccess";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}