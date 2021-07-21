using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class ClearSavedInfo : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Credentials = 1 << 0,
			Info = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -667062079; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("credentials")]
		public bool Credentials { get; set; }

[JsonPropertyName("info")]
		public bool Info { get; set; }


		public void UpdateFlags() 
		{
			Flags = Credentials ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Info ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

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
			Credentials = FlagsHelper.IsFlagSet(Flags, 0);
			Info = FlagsHelper.IsFlagSet(Flags, 1);

		}
	}
}