using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class LangPackLanguageBase : IObject
    {

[JsonPropertyName("official")]
		public abstract bool Official { get; set; }

[JsonPropertyName("rtl")]
		public abstract bool Rtl { get; set; }

[JsonPropertyName("beta")]
		public abstract bool Beta { get; set; }

[JsonPropertyName("name")]
		public abstract string Name { get; set; }

[JsonPropertyName("native_name")]
		public abstract string NativeName { get; set; }

[JsonPropertyName("lang_code")]
		public abstract string LangCode { get; set; }

[JsonPropertyName("base_lang_code")]
		public abstract string BaseLangCode { get; set; }

[JsonPropertyName("plural_code")]
		public abstract string PluralCode { get; set; }

[JsonPropertyName("strings_count")]
		public abstract int StringsCount { get; set; }

[JsonPropertyName("translated_count")]
		public abstract int TranslatedCount { get; set; }

[JsonPropertyName("translations_url")]
		public abstract string TranslationsUrl { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
