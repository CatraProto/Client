using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PaymentChargeBase : IObject
    {

[JsonPropertyName("id")]
		public abstract string Id { get; set; }

[JsonPropertyName("provider_charge_id")]
		public abstract string ProviderChargeId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
