using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentReceiptBase : IObject
    {
        public abstract int Date { get; set; }
        public abstract int BotId { get; set; }
        public abstract InvoiceBase Invoice { get; set; }
        public abstract int ProviderId { get; set; }
        public abstract PaymentRequestedInfoBase Info { get; set; }
        public abstract ShippingOptionBase Shipping { get; set; }
        public abstract string Currency { get; set; }
        public abstract long TotalAmount { get; set; }
        public abstract string CredentialsTitle { get; set; }
        public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}