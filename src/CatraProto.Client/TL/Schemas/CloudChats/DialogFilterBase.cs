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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogFilterBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("contacts")]
        public abstract bool Contacts { get; set; }

        [Newtonsoft.Json.JsonProperty("non_contacts")]
        public abstract bool NonContacts { get; set; }

        [Newtonsoft.Json.JsonProperty("groups")]
        public abstract bool Groups { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcasts")]
        public abstract bool Broadcasts { get; set; }

        [Newtonsoft.Json.JsonProperty("bots")]
        public abstract bool Bots { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_muted")]
        public abstract bool ExcludeMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_read")]
        public abstract bool ExcludeRead { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_archived")]
        public abstract bool ExcludeArchived { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("emoticon")]
        public abstract string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_peers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> PinnedPeers { get; set; }

        [Newtonsoft.Json.JsonProperty("include_peers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> IncludePeers { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_peers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ExcludePeers { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
