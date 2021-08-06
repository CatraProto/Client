using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetContentSettings : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			SensitiveEnabled = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1250643605; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("sensitive_enabled")]
		public bool SensitiveEnabled { get; set; }


		public void UpdateFlags() 
		{
			Flags = SensitiveEnabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			SensitiveEnabled = FlagsHelper.IsFlagSet(Flags, 0);

		}
	}
}