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
    public abstract class StickerSetBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("archived")]
        public abstract bool Archived { get; set; }

        [Newtonsoft.Json.JsonProperty("official")]
        public abstract bool Official { get; set; }

        [Newtonsoft.Json.JsonProperty("masks")]
        public abstract bool Masks { get; set; }

        [Newtonsoft.Json.JsonProperty("animated")]
        public abstract bool Animated { get; set; }

        [Newtonsoft.Json.JsonProperty("videos")]
        public abstract bool Videos { get; set; }

        [Newtonsoft.Json.JsonProperty("installed_date")]
        public abstract int? InstalledDate { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public abstract long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public abstract string ShortName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("thumbs")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb_dc_id")]
        public abstract int? ThumbDcId { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb_version")]
        public abstract int? ThumbVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public abstract int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public abstract int Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
