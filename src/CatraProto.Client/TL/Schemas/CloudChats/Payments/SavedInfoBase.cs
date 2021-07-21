using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class SavedInfoBase : IObject
    {

[JsonPropertyName("has_saved_credentials")]
		public abstract bool HasSavedCredentials { get; set; }

[JsonPropertyName("SavedInfo_")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo_ { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
