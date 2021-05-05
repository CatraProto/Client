using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class LangPackLanguageBase : IObject
    {
		public abstract bool Official { get; set; }
		public abstract bool Rtl { get; set; }
		public abstract bool Beta { get; set; }
		public abstract string Name { get; set; }
		public abstract string NativeName { get; set; }
		public abstract string LangCode { get; set; }
		public abstract string BaseLangCode { get; set; }
		public abstract string PluralCode { get; set; }
		public abstract int StringsCount { get; set; }
		public abstract int TranslatedCount { get; set; }
		public abstract string TranslationsUrl { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
