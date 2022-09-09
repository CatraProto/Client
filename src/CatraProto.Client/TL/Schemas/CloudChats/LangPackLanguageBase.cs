using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class LangPackLanguageBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("official")]
        public abstract bool Official { get; set; }

        [Newtonsoft.Json.JsonProperty("rtl")] public abstract bool Rtl { get; set; }

        [Newtonsoft.Json.JsonProperty("beta")] public abstract bool Beta { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public abstract string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("native_name")]
        public abstract string NativeName { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public abstract string LangCode { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("base_lang_code")]
        public abstract string BaseLangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("plural_code")]
        public abstract string PluralCode { get; set; }

        [Newtonsoft.Json.JsonProperty("strings_count")]
        public abstract int StringsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("translated_count")]
        public abstract int TranslatedCount { get; set; }

        [Newtonsoft.Json.JsonProperty("translations_url")]
        public abstract string TranslationsUrl { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}