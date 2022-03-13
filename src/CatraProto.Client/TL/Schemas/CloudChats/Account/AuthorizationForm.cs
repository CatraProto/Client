using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AuthorizationForm : CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			PrivacyPolicyUrl = 1 << 0
		}

        public static int StaticConstructorId { get => -1389486888; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("required_types")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> RequiredTypes { get; set; }

[Newtonsoft.Json.JsonProperty("values")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

[Newtonsoft.Json.JsonProperty("errors")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("privacy_policy_url")]
		public sealed override string PrivacyPolicyUrl { get; set; }


        #nullable enable
 public AuthorizationForm (IList<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> requiredTypes,IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> values,IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> errors,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 RequiredTypes = requiredTypes;
Values = values;
Errors = errors;
Users = users;
 
}
#nullable disable
        internal AuthorizationForm() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = PrivacyPolicyUrl == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(RequiredTypes);
			writer.Write(Values);
			writer.Write(Errors);
			writer.Write(Users);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(PrivacyPolicyUrl);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			RequiredTypes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase>();
			Values = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
			Errors = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				PrivacyPolicyUrl = reader.Read<string>();
			}


		}
				
		public override string ToString()
		{
		    return "account.authorizationForm";
		}
	}
}