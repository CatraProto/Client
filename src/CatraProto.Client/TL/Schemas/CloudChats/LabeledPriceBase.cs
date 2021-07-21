using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class LabeledPriceBase : IObject
    {

[JsonPropertyName("label")]
		public abstract string Label { get; set; }

[JsonPropertyName("amount")]
		public abstract long Amount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
