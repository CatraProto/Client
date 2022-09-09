using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        [Newtonsoft.Json.JsonProperty("form_id")]
        public abstract long FormId { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public abstract long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public abstract string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("invoice")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

        [Newtonsoft.Json.JsonProperty("provider_id")]
        public abstract long ProviderId { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public abstract string Url { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("native_provider")]
        public abstract string NativeProvider { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("native_params")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase NativeParams { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_info")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_credentials")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase SavedCredentials { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

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