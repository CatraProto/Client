using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EmojiKeywordBase : IObject
    {

[JsonPropertyName("keyword")]
		public abstract string Keyword { get; set; }

[JsonPropertyName("emoticons")]
		public abstract IList<string> Emoticons { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
