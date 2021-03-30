using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PaymentRequestedInfoBase : IObject
    {
		public abstract string Name { get; set; }
		public abstract string Phone { get; set; }
		public abstract string Email { get; set; }
		public abstract PostAddressBase ShippingAddress { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
