using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

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

        [JsonIgnore]
        public static int StaticConstructorId { get => 1754754159; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("no_muted")]
		public bool NoMuted { get; set; }

[JsonPropertyName("token_type")]
		public int TokenType { get; set; }

[JsonPropertyName("token")]
		public string Token { get; set; }

[JsonPropertyName("app_sandbox")]
		public bool AppSandbox { get; set; }

[JsonPropertyName("secret")]
		public byte[] Secret { get; set; }

[JsonPropertyName("other_uids")]
		public IList<int> OtherUids { get; set; }


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
			OtherUids = reader.ReadVector<int>();

		}
	}
}