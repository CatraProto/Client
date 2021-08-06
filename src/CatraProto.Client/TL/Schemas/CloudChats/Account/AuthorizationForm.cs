using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("required_types")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> RequiredTypes { get; set; }

[JsonPropertyName("values")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

[JsonPropertyName("errors")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }

[JsonPropertyName("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[JsonPropertyName("privacy_policy_url")]
		public override string PrivacyPolicyUrl { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = PrivacyPolicyUrl == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}