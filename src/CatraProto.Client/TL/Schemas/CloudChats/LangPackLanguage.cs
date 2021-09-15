using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackLanguage : CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Official = 1 << 0,
			Rtl = 1 << 2,
			Beta = 1 << 3,
			BaseLangCode = 1 << 1
		}

        public static int StaticConstructorId { get => -288727837; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("official")]
		public override bool Official { get; set; }

[Newtonsoft.Json.JsonProperty("rtl")]
		public override bool Rtl { get; set; }

[Newtonsoft.Json.JsonProperty("beta")]
		public override bool Beta { get; set; }

[Newtonsoft.Json.JsonProperty("name")]
		public override string Name { get; set; }

[Newtonsoft.Json.JsonProperty("native_name")]
		public override string NativeName { get; set; }

[Newtonsoft.Json.JsonProperty("lang_code")]
		public override string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("base_lang_code")]
		public override string BaseLangCode { get; set; }

[Newtonsoft.Json.JsonProperty("plural_code")]
		public override string PluralCode { get; set; }

[Newtonsoft.Json.JsonProperty("strings_count")]
		public override int StringsCount { get; set; }

[Newtonsoft.Json.JsonProperty("translated_count")]
		public override int TranslatedCount { get; set; }

[Newtonsoft.Json.JsonProperty("translations_url")]
		public override string TranslationsUrl { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Official ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Rtl ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Beta ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = BaseLangCode == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Name);
			writer.Write(NativeName);
			writer.Write(LangCode);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(BaseLangCode);
			}

			writer.Write(PluralCode);
			writer.Write(StringsCount);
			writer.Write(TranslatedCount);
			writer.Write(TranslationsUrl);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Official = FlagsHelper.IsFlagSet(Flags, 0);
			Rtl = FlagsHelper.IsFlagSet(Flags, 2);
			Beta = FlagsHelper.IsFlagSet(Flags, 3);
			Name = reader.Read<string>();
			NativeName = reader.Read<string>();
			LangCode = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				BaseLangCode = reader.Read<string>();
			}

			PluralCode = reader.Read<string>();
			StringsCount = reader.Read<int>();
			TranslatedCount = reader.Read<int>();
			TranslationsUrl = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "langPackLanguage";
		}
	}
}