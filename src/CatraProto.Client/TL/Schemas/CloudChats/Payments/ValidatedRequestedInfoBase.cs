using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class ValidatedRequestedInfoBase : IObject
    {

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("id")]
        public abstract string Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_options")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> ShippingOptions { get; set; }

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
