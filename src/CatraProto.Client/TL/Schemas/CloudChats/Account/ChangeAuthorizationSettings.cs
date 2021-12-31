using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ChangeAuthorizationSettings : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			EncryptedRequestsDisabled = 1 << 0,
			CallRequestsDisabled = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1089766498; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("encrypted_requests_disabled")]
		public bool? EncryptedRequestsDisabled { get; set; }

[Newtonsoft.Json.JsonProperty("call_requests_disabled")]
		public bool? CallRequestsDisabled { get; set; }


		public void UpdateFlags() 
		{
			Flags = EncryptedRequestsDisabled == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = CallRequestsDisabled == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Hash);
			writer.Write(EncryptedRequestsDisabled.Value);
			writer.Write(CallRequestsDisabled.Value);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Hash = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
			EncryptedRequestsDisabled = reader.Read<bool>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
			CallRequestsDisabled = reader.Read<bool>();
			}


		}
		
		public override string ToString()
		{
		    return "account.changeAuthorizationSettings";
		}
	}
}