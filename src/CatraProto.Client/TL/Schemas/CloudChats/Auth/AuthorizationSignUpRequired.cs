using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class AuthorizationSignUpRequired : CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			TermsOfService = 1 << 0
		}

        public static int StaticConstructorId { get => 1148485274; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("terms_of_service")]
		public CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase TermsOfService { get; set; }


        
        public AuthorizationSignUpRequired() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = TermsOfService == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TermsOfService);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TermsOfService = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase>();
			}


		}
				
		public override string ToString()
		{
		    return "auth.authorizationSignUpRequired";
		}
	}
}