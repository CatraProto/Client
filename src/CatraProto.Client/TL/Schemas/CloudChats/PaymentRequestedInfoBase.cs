using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PaymentRequestedInfoBase : IObject
    {

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("name")]
        public abstract string Name { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("phone")]
        public abstract string Phone { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email")]
        public abstract string Email { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_address")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase ShippingAddress { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}
