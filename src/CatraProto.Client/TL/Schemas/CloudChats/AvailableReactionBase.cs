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
    public abstract class AvailableReactionBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("inactive")]
        public abstract bool Inactive { get; set; }

        [Newtonsoft.Json.JsonProperty("premium")]
        public abstract bool Premium { get; set; }

        [Newtonsoft.Json.JsonProperty("reaction")]
        public abstract string Reaction { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("static_icon")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase StaticIcon { get; set; }

        [Newtonsoft.Json.JsonProperty("appear_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase AppearAnimation { get; set; }

        [Newtonsoft.Json.JsonProperty("select_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase SelectAnimation { get; set; }

        [Newtonsoft.Json.JsonProperty("activate_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase ActivateAnimation { get; set; }

        [Newtonsoft.Json.JsonProperty("effect_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase EffectAnimation { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("around_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase AroundAnimation { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("center_icon")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase CenterIcon { get; set; }

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
