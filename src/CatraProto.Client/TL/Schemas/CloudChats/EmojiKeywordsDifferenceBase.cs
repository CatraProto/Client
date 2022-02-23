using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EmojiKeywordsDifferenceBase : IObject
    {

[Newtonsoft.Json.JsonProperty("lang_code")]
		public abstract string LangCode { get; set; }

[Newtonsoft.Json.JsonProperty("from_version")]
		public abstract int FromVersion { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public abstract int Version { get; set; }

[Newtonsoft.Json.JsonProperty("keywords")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> Keywords { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
