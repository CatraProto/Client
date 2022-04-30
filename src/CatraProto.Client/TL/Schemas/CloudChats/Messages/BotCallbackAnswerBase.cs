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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotCallbackAnswerBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("alert")]
        public abstract bool Alert { get; set; }

        [Newtonsoft.Json.JsonProperty("has_url")]
        public abstract bool HasUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("native_ui")]
        public abstract bool NativeUi { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("message")]
        public abstract string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public abstract string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("cache_time")]
        public abstract int CacheTime { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
