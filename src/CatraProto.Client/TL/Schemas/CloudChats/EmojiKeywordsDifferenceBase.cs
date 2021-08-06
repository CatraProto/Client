using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EmojiKeywordsDifferenceBase : IObject
    {

[JsonPropertyName("lang_code")]
		public abstract string LangCode { get; set; }

[JsonPropertyName("from_version")]
		public abstract int FromVersion { get; set; }

[JsonPropertyName("version")]
		public abstract int Version { get; set; }

[JsonPropertyName("keywords")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> Keywords { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
