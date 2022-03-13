using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Password : CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasRecovery = 1 << 0,
			HasSecureValues = 1 << 1,
			HasPassword = 1 << 2,
			CurrentAlgo = 1 << 2,
			SrpB = 1 << 2,
			SrpId = 1 << 2,
			Hint = 1 << 3,
			EmailUnconfirmedPattern = 1 << 4,
			PendingResetDate = 1 << 5
		}

        public static int StaticConstructorId { get => 408623183; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("has_recovery")]
		public sealed override bool HasRecovery { get; set; }

[Newtonsoft.Json.JsonProperty("has_secure_values")]
		public sealed override bool HasSecureValues { get; set; }

[Newtonsoft.Json.JsonProperty("has_password")]
		public sealed override bool HasPassword { get; set; }

[Newtonsoft.Json.JsonProperty("current_algo")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase CurrentAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("srp_B")]
		public sealed override byte[] SrpB { get; set; }

[Newtonsoft.Json.JsonProperty("srp_id")]
		public sealed override long? SrpId { get; set; }

[Newtonsoft.Json.JsonProperty("hint")]
		public sealed override string Hint { get; set; }

[Newtonsoft.Json.JsonProperty("email_unconfirmed_pattern")]
		public sealed override string EmailUnconfirmedPattern { get; set; }

[Newtonsoft.Json.JsonProperty("new_algo")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("new_secure_algo")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }

[Newtonsoft.Json.JsonProperty("secure_random")]
		public sealed override byte[] SecureRandom { get; set; }

[Newtonsoft.Json.JsonProperty("pending_reset_date")]
		public sealed override int? PendingResetDate { get; set; }


        #nullable enable
 public Password (CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase newAlgo,CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase newSecureAlgo,byte[] secureRandom)
{
 NewAlgo = newAlgo;
NewSecureAlgo = newSecureAlgo;
SecureRandom = secureRandom;
 
}
#nullable disable
        internal Password() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = HasRecovery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = HasSecureValues ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = HasPassword ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = CurrentAlgo == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = SrpB == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = SrpId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Hint == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = EmailUnconfirmedPattern == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = PendingResetDate == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(CurrentAlgo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SrpB);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(SrpId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Hint);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(EmailUnconfirmedPattern);
			}

			writer.Write(NewAlgo);
			writer.Write(NewSecureAlgo);
			writer.Write(SecureRandom);
			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(PendingResetDate.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasRecovery = FlagsHelper.IsFlagSet(Flags, 0);
			HasSecureValues = FlagsHelper.IsFlagSet(Flags, 1);
			HasPassword = FlagsHelper.IsFlagSet(Flags, 2);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				CurrentAlgo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				SrpB = reader.Read<byte[]>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				SrpId = reader.Read<long>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Hint = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				EmailUnconfirmedPattern = reader.Read<string>();
			}

			NewAlgo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase>();
			NewSecureAlgo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase>();
			SecureRandom = reader.Read<byte[]>();
			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				PendingResetDate = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "account.password";
		}
	}
}