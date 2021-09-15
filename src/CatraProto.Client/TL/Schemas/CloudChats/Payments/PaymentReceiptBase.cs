using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentReceiptBase : IObject
    {

[Newtonsoft.Json.JsonProperty("date")]
		public abstract int Date { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public abstract int BotId { get; set; }

[Newtonsoft.Json.JsonProperty("invoice")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[Newtonsoft.Json.JsonProperty("provider_id")]
		public abstract int ProviderId { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

[Newtonsoft.Json.JsonProperty("shipping")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase Shipping { get; set; }

[Newtonsoft.Json.JsonProperty("currency")]
		public abstract string Currency { get; set; }

[Newtonsoft.Json.JsonProperty("total_amount")]
		public abstract long TotalAmount { get; set; }

[Newtonsoft.Json.JsonProperty("credentials_title")]
		public abstract string CredentialsTitle { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
