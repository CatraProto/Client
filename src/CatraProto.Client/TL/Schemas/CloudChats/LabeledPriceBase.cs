using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class LabeledPriceBase : IObject
    {

[Newtonsoft.Json.JsonProperty("label")]
		public abstract string Label { get; set; }

[Newtonsoft.Json.JsonProperty("amount")]
		public abstract long Amount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
