using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentFormBase : IObject
    {
		public abstract bool CanSaveCredentials { get; set; }
		public abstract bool PasswordMissing { get; set; }
		public abstract int BotId { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }
		public abstract int ProviderId { get; set; }
		public abstract string Url { get; set; }
		public abstract string NativeProvider { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
