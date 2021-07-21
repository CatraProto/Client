using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollAnswerBase : IObject
    {

[JsonPropertyName("text")]
		public abstract string Text { get; set; }

[JsonPropertyName("option")]
		public abstract byte[] Option { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
