using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentReceiptBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("date")] public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public abstract long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("provider_id")]
        public abstract long ProviderId { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public abstract string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("invoice")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("info")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase Shipping { get; set; }

        [Newtonsoft.Json.JsonProperty("tip_amount")]
        public abstract long? TipAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public abstract string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public abstract long TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials_title")]
        public abstract string CredentialsTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}