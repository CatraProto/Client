/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
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

        [Newtonsoft.Json.JsonProperty("url")]
        public abstract string Url { get; set; }

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
