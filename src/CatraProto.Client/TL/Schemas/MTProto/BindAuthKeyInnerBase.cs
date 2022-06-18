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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class BindAuthKeyInnerBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("nonce")]
        public abstract long Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_auth_key_id")]
        public abstract long TempAuthKeyId { get; set; }

        [Newtonsoft.Json.JsonProperty("perm_auth_key_id")]
        public abstract long PermAuthKeyId { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_session_id")]
        public abstract long TempSessionId { get; set; }

        [Newtonsoft.Json.JsonProperty("expires_at")]
        public abstract int ExpiresAt { get; set; }

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
