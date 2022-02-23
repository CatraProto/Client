using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ShippingOptionBase : IObject
    {

[Newtonsoft.Json.JsonProperty("id")]
		public abstract string Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public abstract string Title { get; set; }

[Newtonsoft.Json.JsonProperty("prices")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
