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
    public abstract class GroupCallParticipantBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("muted")]
        public abstract bool Muted { get; set; }

        [Newtonsoft.Json.JsonProperty("left")]
        public abstract bool Left { get; set; }

        [Newtonsoft.Json.JsonProperty("can_self_unmute")]
        public abstract bool CanSelfUnmute { get; set; }

        [Newtonsoft.Json.JsonProperty("just_joined")]
        public abstract bool JustJoined { get; set; }

        [Newtonsoft.Json.JsonProperty("versioned")]
        public abstract bool Versioned { get; set; }

        [Newtonsoft.Json.JsonProperty("min")]
        public abstract bool Min { get; set; }

        [Newtonsoft.Json.JsonProperty("muted_by_you")]
        public abstract bool MutedByYou { get; set; }

        [Newtonsoft.Json.JsonProperty("volume_by_admin")]
        public abstract bool VolumeByAdmin { get; set; }

        [Newtonsoft.Json.JsonProperty("self")]
        public abstract bool Self { get; set; }

        [Newtonsoft.Json.JsonProperty("video_joined")]
        public abstract bool VideoJoined { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("active_date")]
        public abstract int? ActiveDate { get; set; }

        [Newtonsoft.Json.JsonProperty("source")]
        public abstract int Source { get; set; }

        [Newtonsoft.Json.JsonProperty("volume")]
        public abstract int? Volume { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public abstract string About { get; set; }

        [Newtonsoft.Json.JsonProperty("raise_hand_rating")]
        public abstract long? RaiseHandRating { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("video")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase Video { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("presentation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoBase Presentation { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
