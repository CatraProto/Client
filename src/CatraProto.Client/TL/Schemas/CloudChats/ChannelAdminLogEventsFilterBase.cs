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
    public abstract class ChannelAdminLogEventsFilterBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("join")]
        public abstract bool Join { get; set; }

        [Newtonsoft.Json.JsonProperty("leave")]
        public abstract bool Leave { get; set; }

        [Newtonsoft.Json.JsonProperty("invite")]
        public abstract bool Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("ban")]
        public abstract bool Ban { get; set; }

        [Newtonsoft.Json.JsonProperty("unban")]
        public abstract bool Unban { get; set; }

        [Newtonsoft.Json.JsonProperty("kick")]
        public abstract bool Kick { get; set; }

        [Newtonsoft.Json.JsonProperty("unkick")]
        public abstract bool Unkick { get; set; }

        [Newtonsoft.Json.JsonProperty("promote")]
        public abstract bool Promote { get; set; }

        [Newtonsoft.Json.JsonProperty("demote")]
        public abstract bool Demote { get; set; }

        [Newtonsoft.Json.JsonProperty("info")]
        public abstract bool Info { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public abstract bool Settings { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned")]
        public abstract bool Pinned { get; set; }

        [Newtonsoft.Json.JsonProperty("edit")]
        public abstract bool Edit { get; set; }

        [Newtonsoft.Json.JsonProperty("delete")]
        public abstract bool Delete { get; set; }

        [Newtonsoft.Json.JsonProperty("group_call")]
        public abstract bool GroupCall { get; set; }

        [Newtonsoft.Json.JsonProperty("invites")]
        public abstract bool Invites { get; set; }

        [Newtonsoft.Json.JsonProperty("send")]
        public abstract bool Send { get; set; }

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
