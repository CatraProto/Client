using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class ValidatedRequestedInfoBase : IObject
    {

[JsonPropertyName("id")]
		public abstract string Id { get; set; }

[JsonPropertyName("shipping_options")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> ShippingOptions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
