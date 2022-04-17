using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
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
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> Keywords { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
