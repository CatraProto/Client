using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentReceiptBase : IObject
    {
		public abstract int Date { get; set; }
		public abstract int BotId { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }
		public abstract int ProviderId { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase Shipping { get; set; }
		public abstract string Currency { get; set; }
		public abstract long TotalAmount { get; set; }
		public abstract string CredentialsTitle { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
