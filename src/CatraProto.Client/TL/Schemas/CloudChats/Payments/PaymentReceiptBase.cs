using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentReceiptBase : IObject
    {

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

[JsonPropertyName("bot_id")]
		public abstract int BotId { get; set; }

[JsonPropertyName("invoice")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[JsonPropertyName("provider_id")]
		public abstract int ProviderId { get; set; }

[JsonPropertyName("info")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

[JsonPropertyName("shipping")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase Shipping { get; set; }

[JsonPropertyName("currency")]
		public abstract string Currency { get; set; }

[JsonPropertyName("total_amount")]
		public abstract long TotalAmount { get; set; }

[JsonPropertyName("credentials_title")]
		public abstract string CredentialsTitle { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
