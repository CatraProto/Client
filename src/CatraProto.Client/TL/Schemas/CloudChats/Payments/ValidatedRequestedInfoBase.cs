using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class ValidatedRequestedInfoBase : IObject
    {

[Newtonsoft.Json.JsonProperty("id")]
		public abstract string Id { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_options")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> ShippingOptions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
