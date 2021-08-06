using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class RestrictionReasonBase : IObject
    {

[JsonPropertyName("platform")]
		public abstract string Platform { get; set; }

[JsonPropertyName("reason")]
		public abstract string Reason { get; set; }

[JsonPropertyName("text")]
		public abstract string Text { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
