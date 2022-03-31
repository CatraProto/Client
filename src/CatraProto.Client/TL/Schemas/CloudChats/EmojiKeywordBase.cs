using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EmojiKeywordBase : IObject
    {

[Newtonsoft.Json.JsonProperty("keyword")]
		public abstract string Keyword { get; set; }

[Newtonsoft.Json.JsonProperty("emoticons")]
		public abstract IList<string> Emoticons { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
