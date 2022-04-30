/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class LangPackLanguageBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("official")]
        public abstract bool Official { get; set; }

        [Newtonsoft.Json.JsonProperty("rtl")]
        public abstract bool Rtl { get; set; }

        [Newtonsoft.Json.JsonProperty("beta")]
        public abstract bool Beta { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public abstract string Name { get; set; }

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
#nullable disable
    }
}
