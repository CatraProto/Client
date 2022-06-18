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
    public partial class PhoneConnection : CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1655957568; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public sealed override string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("ipv6")]
        public sealed override string Ipv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("port")]
        public sealed override int Port { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_tag")]
        public byte[] PeerTag { get; set; }


#nullable enable
        public PhoneConnection(long id, string ip, string ipv6, int port, byte[] peerTag)
        {
            Id = id;
            Ip = ip;
            Ipv6 = ipv6;
            Port = port;
            PeerTag = peerTag;

        }
#nullable disable
        internal PhoneConnection()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);

            writer.WriteString(Ip);

            writer.WriteString(Ipv6);
            writer.WriteInt32(Port);

            writer.WriteBytes(PeerTag);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryip = reader.ReadString();
            if (tryip.IsError)
            {
                return ReadResult<IObject>.Move(tryip);
            }
            Ip = tryip.Value;
            var tryipv6 = reader.ReadString();
            if (tryipv6.IsError)
            {
                return ReadResult<IObject>.Move(tryipv6);
            }
            Ipv6 = tryipv6.Value;
            var tryport = reader.ReadInt32();
            if (tryport.IsError)
            {
                return ReadResult<IObject>.Move(tryport);
            }
            Port = tryport.Value;
            var trypeerTag = reader.ReadBytes();
            if (trypeerTag.IsError)
            {
                return ReadResult<IObject>.Move(trypeerTag);
            }
            PeerTag = trypeerTag.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phoneConnection";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneConnection
            {
                Id = Id,
                Ip = Ip,
                Ipv6 = Ipv6,
                Port = Port,
                PeerTag = PeerTag
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PhoneConnection castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (Ip != castedOther.Ip)
            {
                return true;
            }
            if (Ipv6 != castedOther.Ipv6)
            {
                return true;
            }
            if (Port != castedOther.Port)
            {
                return true;
            }
            if (PeerTag != castedOther.PeerTag)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}