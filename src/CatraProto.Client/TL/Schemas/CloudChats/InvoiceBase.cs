using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InvoiceBase : IObject
    {
		public abstract bool Test { get; set; }
		public abstract bool NameRequested { get; set; }
		public abstract bool PhoneRequested { get; set; }
		public abstract bool EmailRequested { get; set; }
		public abstract bool ShippingAddressRequested { get; set; }
		public abstract bool Flexible { get; set; }
		public abstract bool PhoneToProvider { get; set; }
		public abstract bool EmailToProvider { get; set; }
		public abstract string Currency { get; set; }
		public abstract IList<LabeledPriceBase> Prices { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
