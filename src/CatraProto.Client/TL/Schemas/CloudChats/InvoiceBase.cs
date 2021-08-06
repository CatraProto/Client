using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InvoiceBase : IObject
    {

[JsonPropertyName("test")]
		public abstract bool Test { get; set; }

[JsonPropertyName("name_requested")]
		public abstract bool NameRequested { get; set; }

[JsonPropertyName("phone_requested")]
		public abstract bool PhoneRequested { get; set; }

[JsonPropertyName("email_requested")]
		public abstract bool EmailRequested { get; set; }

[JsonPropertyName("shipping_address_requested")]
		public abstract bool ShippingAddressRequested { get; set; }

[JsonPropertyName("flexible")]
		public abstract bool Flexible { get; set; }

[JsonPropertyName("phone_to_provider")]
		public abstract bool PhoneToProvider { get; set; }

[JsonPropertyName("email_to_provider")]
		public abstract bool EmailToProvider { get; set; }

[JsonPropertyName("currency")]
		public abstract string Currency { get; set; }

[JsonPropertyName("prices")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
