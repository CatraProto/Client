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
    public abstract class PeerSettingsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("report_spam")]
        public abstract bool ReportSpam { get; set; }

        [Newtonsoft.Json.JsonProperty("add_contact")]
        public abstract bool AddContact { get; set; }

        [Newtonsoft.Json.JsonProperty("block_contact")]
        public abstract bool BlockContact { get; set; }

        [Newtonsoft.Json.JsonProperty("share_contact")]
        public abstract bool ShareContact { get; set; }

        [Newtonsoft.Json.JsonProperty("need_contacts_exception")]
        public abstract bool NeedContactsException { get; set; }

        [Newtonsoft.Json.JsonProperty("report_geo")]
        public abstract bool ReportGeo { get; set; }

        [Newtonsoft.Json.JsonProperty("autoarchived")]
        public abstract bool Autoarchived { get; set; }

        [Newtonsoft.Json.JsonProperty("invite_members")]
        public abstract bool InviteMembers { get; set; }

        [Newtonsoft.Json.JsonProperty("request_chat_broadcast")]
        public abstract bool RequestChatBroadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("geo_distance")]
        public abstract int? GeoDistance { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("request_chat_title")]
        public abstract string RequestChatTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("request_chat_date")]
        public abstract int? RequestChatDate { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
