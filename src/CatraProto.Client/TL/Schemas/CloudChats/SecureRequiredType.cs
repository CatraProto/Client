using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureRequiredType : CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NativeNames = 1 << 0,
			SelfieRequired = 1 << 1,
			TranslationRequired = 1 << 2
		}

        public static int StaticConstructorId { get => -2103600678; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("native_names")]
		public bool NativeNames { get; set; }

[Newtonsoft.Json.JsonProperty("selfie_required")]
		public bool SelfieRequired { get; set; }

[Newtonsoft.Json.JsonProperty("translation_required")]
		public bool TranslationRequired { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }


        #nullable enable
 public SecureRequiredType (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type)
{
 Type = type;
 
}
#nullable disable
        internal SecureRequiredType() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = NativeNames ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SelfieRequired ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = TranslationRequired ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();

		}
				
		public override string ToString()
		{
		    return "secureRequiredType";
		}
	}
}