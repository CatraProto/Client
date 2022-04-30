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
    public abstract class MessageRepliesBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("comments")]
        public abstract bool Comments { get; set; }

        [Newtonsoft.Json.JsonProperty("replies")]
        public abstract int Replies { get; set; }

        [Newtonsoft.Json.JsonProperty("replies_pts")]
        public abstract int RepliesPts { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("recent_repliers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> RecentRepliers { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public abstract long? ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public abstract int? MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_max_id")]
        public abstract int? ReadMaxId { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
