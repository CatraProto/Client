using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class RegisterDevice : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoMuted = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -326762118; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("no_muted")]
		public bool NoMuted { get; set; }

[Newtonsoft.Json.JsonProperty("token_type")]
		public int TokenType { get; set; }

[Newtonsoft.Json.JsonProperty("token")]
		public string Token { get; set; }

[Newtonsoft.Json.JsonProperty("app_sandbox")]
		public bool AppSandbox { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public byte[] Secret { get; set; }

[Newtonsoft.Json.JsonProperty("other_uids")]
		public IList<long> OtherUids { get; set; }


		public void UpdateFlags() 
		{
			Flags = NoMuted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(TokenType);
			writer.Write(Token);
			writer.Write(AppSandbox);
			writer.Write(Secret);
			writer.Write(OtherUids);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoMuted = FlagsHelper.IsFlagSet(Flags, 0);
			TokenType = reader.Read<int>();
			Token = reader.Read<string>();
			AppSandbox = reader.Read<bool>();
			Secret = reader.Read<byte[]>();
			OtherUids = reader.ReadVector<long>();

		}
		
		public override string ToString()
		{
		    return "account.registerDevice";
		}
	}
}