using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PaymentRequestedInfoBase : IObject
    {

[Newtonsoft.Json.JsonProperty("name")]
		public abstract string Name { get; set; }

[Newtonsoft.Json.JsonProperty("phone")]
		public abstract string Phone { get; set; }

[Newtonsoft.Json.JsonProperty("email")]
		public abstract string Email { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_address")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase ShippingAddress { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
