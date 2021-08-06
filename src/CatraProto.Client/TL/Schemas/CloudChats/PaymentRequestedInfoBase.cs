using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PaymentRequestedInfoBase : IObject
    {

[JsonPropertyName("name")]
		public abstract string Name { get; set; }

[JsonPropertyName("phone")]
		public abstract string Phone { get; set; }

[JsonPropertyName("email")]
		public abstract string Email { get; set; }

[JsonPropertyName("shipping_address")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase ShippingAddress { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
