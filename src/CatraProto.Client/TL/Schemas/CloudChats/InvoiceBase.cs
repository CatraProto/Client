using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InvoiceBase : IObject
    {

[Newtonsoft.Json.JsonProperty("test")]
		public abstract bool Test { get; set; }

[Newtonsoft.Json.JsonProperty("name_requested")]
		public abstract bool NameRequested { get; set; }

[Newtonsoft.Json.JsonProperty("phone_requested")]
		public abstract bool PhoneRequested { get; set; }

[Newtonsoft.Json.JsonProperty("email_requested")]
		public abstract bool EmailRequested { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_address_requested")]
		public abstract bool ShippingAddressRequested { get; set; }

[Newtonsoft.Json.JsonProperty("flexible")]
		public abstract bool Flexible { get; set; }

[Newtonsoft.Json.JsonProperty("phone_to_provider")]
		public abstract bool PhoneToProvider { get; set; }

[Newtonsoft.Json.JsonProperty("email_to_provider")]
		public abstract bool EmailToProvider { get; set; }

[Newtonsoft.Json.JsonProperty("currency")]
		public abstract string Currency { get; set; }

[Newtonsoft.Json.JsonProperty("prices")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

[Newtonsoft.Json.JsonProperty("max_tip_amount")]
		public abstract long? MaxTipAmount { get; set; }

[Newtonsoft.Json.JsonProperty("suggested_tip_amounts")]
		public abstract IList<long> SuggestedTipAmounts { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
