using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class SavedInfoBase : IObject
    {
		public abstract bool HasSavedCredentials { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo_ { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
