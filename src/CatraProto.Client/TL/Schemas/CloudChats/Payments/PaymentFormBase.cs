using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentFormBase : IObject
    {

[JsonPropertyName("can_save_credentials")]
		public abstract bool CanSaveCredentials { get; set; }

[JsonPropertyName("password_missing")]
		public abstract bool PasswordMissing { get; set; }

[JsonPropertyName("bot_id")]
		public abstract int BotId { get; set; }

[JsonPropertyName("invoice")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[JsonPropertyName("provider_id")]
		public abstract int ProviderId { get; set; }

[JsonPropertyName("url")]
		public abstract string Url { get; set; }

[JsonPropertyName("native_provider")]
		public abstract string NativeProvider { get; set; }

[JsonPropertyName("native_params")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }

[JsonPropertyName("saved_info")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }

[JsonPropertyName("saved_credentials")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
