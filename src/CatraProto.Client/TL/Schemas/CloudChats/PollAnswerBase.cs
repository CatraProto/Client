using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollAnswerBase : IObject
    {

[Newtonsoft.Json.JsonProperty("text")]
		public abstract string Text { get; set; }

[Newtonsoft.Json.JsonProperty("option")]
		public abstract byte[] Option { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
