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

using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ExportedChatInviteBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("revoked")]
        public abstract bool Revoked { get; set; }

        [Newtonsoft.Json.JsonProperty("permanent")]
        public abstract bool Permanent { get; set; }

        [Newtonsoft.Json.JsonProperty("request_needed")]
        public abstract bool RequestNeeded { get; set; }

        [Newtonsoft.Json.JsonProperty("link")]
        public abstract string Link { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public abstract long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("start_date")]
        public abstract int? StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("expire_date")]
        public abstract int? ExpireDate { get; set; }

        [Newtonsoft.Json.JsonProperty("usage_limit")]
        public abstract int? UsageLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("usage")]
        public abstract int? Usage { get; set; }

        [Newtonsoft.Json.JsonProperty("requested")]
        public abstract int? Requested { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
