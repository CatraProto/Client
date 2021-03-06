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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AuthorizationBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("current")]
        public abstract bool Current { get; set; }

        [Newtonsoft.Json.JsonProperty("official_app")]
        public abstract bool OfficialApp { get; set; }

        [Newtonsoft.Json.JsonProperty("password_pending")]
        public abstract bool PasswordPending { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_requests_disabled")]
        public abstract bool EncryptedRequestsDisabled { get; set; }

        [Newtonsoft.Json.JsonProperty("call_requests_disabled")]
        public abstract bool CallRequestsDisabled { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public abstract long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("device_model")]
        public abstract string DeviceModel { get; set; }

        [Newtonsoft.Json.JsonProperty("platform")]
        public abstract string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("system_version")]
        public abstract string SystemVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("api_id")]
        public abstract int ApiId { get; set; }

        [Newtonsoft.Json.JsonProperty("app_name")]
        public abstract string AppName { get; set; }

        [Newtonsoft.Json.JsonProperty("app_version")]
        public abstract string AppVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("date_created")]
        public abstract int DateCreated { get; set; }

        [Newtonsoft.Json.JsonProperty("date_active")]
        public abstract int DateActive { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public abstract string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("country")]
        public abstract string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("region")]
        public abstract string Region { get; set; }

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
