using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureRequiredType : SecureRequiredTypeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NativeNames = 1 << 0,
			SelfieRequired = 1 << 1,
			TranslationRequired = 1 << 2
		}

        public static int StaticConstructorId { get => -2103600678; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("native_names")]
		public bool NativeNames { get; set; }

[JsonPropertyName("selfie_required")]
		public bool SelfieRequired { get; set; }

[JsonPropertyName("translation_required")]
		public bool TranslationRequired { get; set; }

[JsonPropertyName("type")]
		public SecureValueTypeBase Type { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = NativeNames ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SelfieRequired ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = TranslationRequired ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Type);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NativeNames = FlagsHelper.IsFlagSet(Flags, 0);
			SelfieRequired = FlagsHelper.IsFlagSet(Flags, 1);
			TranslationRequired = FlagsHelper.IsFlagSet(Flags, 2);
			Type = reader.Read<SecureValueTypeBase>();
		}

		public override string ToString()
		{
			return "secureRequiredType";
		}
	}
}