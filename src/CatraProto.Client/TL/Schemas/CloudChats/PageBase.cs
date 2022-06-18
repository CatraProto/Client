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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("part")]
        public abstract bool Part { get; set; }

        [Newtonsoft.Json.JsonProperty("rtl")]
        public abstract bool Rtl { get; set; }

        [Newtonsoft.Json.JsonProperty("v2")]
        public abstract bool V2 { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public abstract string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

        [Newtonsoft.Json.JsonProperty("photos")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public abstract int? Views { get; set; }

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
