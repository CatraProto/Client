using System;
using CatraProto.TL;

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

        public static int StaticConstructorId
        {
            get => -288727837;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("official")]
        public sealed override bool Official { get; set; }

        [Newtonsoft.Json.JsonProperty("rtl")] public sealed override bool Rtl { get; set; }

        [Newtonsoft.Json.JsonProperty("beta")] public sealed override bool Beta { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("native_name")]
        public sealed override string NativeName { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public sealed override string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("base_lang_code")]
        public sealed override string BaseLangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("plural_code")]
        public sealed override string PluralCode { get; set; }

        [Newtonsoft.Json.JsonProperty("strings_count")]
        public sealed override int StringsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("translated_count")]
        public sealed override int TranslatedCount { get; set; }

        [Newtonsoft.Json.JsonProperty("translations_url")]
        public sealed override string TranslationsUrl { get; set; }


    #nullable enable
        public LangPackLanguage(string name, string nativeName, string langCode, string pluralCode, int stringsCount, int translatedCount, string translationsUrl)
        {
            Name = name;
            NativeName = nativeName;
            LangCode = langCode;
            PluralCode = pluralCode;
            StringsCount = stringsCount;
            TranslatedCount = translatedCount;
            TranslationsUrl = translationsUrl;
        }
    #nullable disable
        internal LangPackLanguage()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Official ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Rtl ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Beta ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = BaseLangCode == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Name);
            writer.Write(NativeName);
            writer.Write(LangCode);
            if (FlagsHelper.IsFlagSet(Flags, 1))
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
            if (FlagsHelper.IsFlagSet(Flags, 1))
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