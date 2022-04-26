using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EmojiKeywordBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("keyword")]
        public abstract string Keyword { get; set; }

        [Newtonsoft.Json.JsonProperty("emoticons")]
        public abstract List<string> Emoticons { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
