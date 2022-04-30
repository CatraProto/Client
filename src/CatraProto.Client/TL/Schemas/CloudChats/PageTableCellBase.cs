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
    public abstract class PageTableCellBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("header")]
        public abstract bool Header { get; set; }

        [Newtonsoft.Json.JsonProperty("align_center")]
        public abstract bool AlignCenter { get; set; }

        [Newtonsoft.Json.JsonProperty("align_right")]
        public abstract bool AlignRight { get; set; }

        [Newtonsoft.Json.JsonProperty("valign_middle")]
        public abstract bool ValignMiddle { get; set; }

        [Newtonsoft.Json.JsonProperty("valign_bottom")]
        public abstract bool ValignBottom { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("text")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("colspan")]
        public abstract int? Colspan { get; set; }

        [Newtonsoft.Json.JsonProperty("rowspan")]
        public abstract int? Rowspan { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
