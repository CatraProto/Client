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
    public abstract class DcOptionBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("ipv6")]
        public abstract bool Ipv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("media_only")]
        public abstract bool MediaOnly { get; set; }

        [Newtonsoft.Json.JsonProperty("tcpo_only")]
        public abstract bool TcpoOnly { get; set; }

        [Newtonsoft.Json.JsonProperty("cdn")]
        public abstract bool Cdn { get; set; }

        [Newtonsoft.Json.JsonProperty("static")]
        public abstract bool Static { get; set; }

        [Newtonsoft.Json.JsonProperty("this_port_only")]
        public abstract bool ThisPortOnly { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ip_address")]
        public abstract string IpAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("port")]
        public abstract int Port { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public abstract byte[] Secret { get; set; }

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
