using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentFormBase : IObject
    {
        public abstract bool CanSaveCredentials { get; set; }
        public abstract bool PasswordMissing { get; set; }
        public abstract int BotId { get; set; }
        public abstract InvoiceBase Invoice { get; set; }
        public abstract int ProviderId { get; set; }
        public abstract string Url { get; set; }
        public abstract string NativeProvider { get; set; }
        public abstract DataJSONBase NativeParams { get; set; }
        public abstract PaymentRequestedInfoBase SavedInfo { get; set; }
        public abstract PaymentSavedCredentialsBase SavedCredentials { get; set; }
        public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}