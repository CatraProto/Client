using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class PaymentFormBase : IObject
    {

[Newtonsoft.Json.JsonProperty("can_save_credentials")]
		public abstract bool CanSaveCredentials { get; set; }

[Newtonsoft.Json.JsonProperty("password_missing")]
		public abstract bool PasswordMissing { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public abstract int BotId { get; set; }

[Newtonsoft.Json.JsonProperty("invoice")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[Newtonsoft.Json.JsonProperty("provider_id")]
		public abstract int ProviderId { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public abstract string Url { get; set; }

[Newtonsoft.Json.JsonProperty("native_provider")]
		public abstract string NativeProvider { get; set; }

[Newtonsoft.Json.JsonProperty("native_params")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }

[Newtonsoft.Json.JsonProperty("saved_info")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }

[Newtonsoft.Json.JsonProperty("saved_credentials")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
