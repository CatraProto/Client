using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class SavedInfoBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("has_saved_credentials")]
        public abstract bool HasSavedCredentials { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_info")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfoField { get; set; }

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