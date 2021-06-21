using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class AuthorizationForm : AuthorizationFormBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			PrivacyPolicyUrl = 1 << 0
		}

        public static int ConstructorId { get; } = -1389486888;
		public int Flags { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> RequiredTypes { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }
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