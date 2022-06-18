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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class Pong : CatraProto.Client.TL.Schemas.MTProto.PongBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 880243653; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("ping_id")]
        public sealed override long PingId { get; set; }


#nullable enable
        public Pong(long msgId, long pingId)
        {
            MsgId = msgId;
            PingId = pingId;

        }
#nullable disable
        internal Pong()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(MsgId);
            writer.WriteInt64(PingId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymsgId = reader.ReadInt64();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }
            MsgId = trymsgId.Value;
            var trypingId = reader.ReadInt64();
            if (trypingId.IsError)
            {
                return ReadResult<IObject>.Move(trypingId);
            }
            PingId = trypingId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Pong
            {
                MsgId = MsgId,
                PingId = PingId
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Pong castedOther)
            {
                return true;
            }
            if (MsgId != castedOther.MsgId)
            {
                return true;
            }
            if (PingId != castedOther.PingId)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}