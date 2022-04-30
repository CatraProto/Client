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
    public partial class Message : CatraProto.Client.TL.Schemas.MTProto.MessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 0; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("seqno")]
        public sealed override int Seqno { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override int Bytes { get; set; }

        [Newtonsoft.Json.JsonProperty("body")]
        public sealed override IObject Body { get; set; }


#nullable enable
        public Message(long msgId, int seqno, int bytes, IObject body)
        {
            MsgId = msgId;
            Seqno = seqno;
            Bytes = bytes;
            Body = body;

        }
#nullable disable
        internal Message()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt64(MsgId);
            writer.WriteInt32(Seqno);
            writer.WriteInt32(Bytes);
            var checkbody = writer.WriteObject(Body);
            if (checkbody.IsError)
            {
                return checkbody;
            }

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
            var tryseqno = reader.ReadInt32();
            if (tryseqno.IsError)
            {
                return ReadResult<IObject>.Move(tryseqno);
            }
            Seqno = tryseqno.Value;
            var trybytes = reader.ReadInt32();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }
            Bytes = trybytes.Value;
            var trybody = reader.ReadObject<IObject>();
            if (trybody.IsError)
            {
                return ReadResult<IObject>.Move(trybody);
            }
            Body = trybody.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "message";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Message
            {
                MsgId = MsgId,
                Seqno = Seqno,
                Bytes = Bytes,
                Body = Body
            };
            return newClonedObject;

        }
#nullable disable
    }
}