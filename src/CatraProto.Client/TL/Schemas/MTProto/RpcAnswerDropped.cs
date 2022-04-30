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
    public partial class RpcAnswerDropped : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1539647305; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("seq_no")]
        public int SeqNo { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public int Bytes { get; set; }


#nullable enable
        public RpcAnswerDropped(long msgId, int seqNo, int bytes)
        {
            MsgId = msgId;
            SeqNo = seqNo;
            Bytes = bytes;

        }
#nullable disable
        internal RpcAnswerDropped()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(MsgId);
            writer.WriteInt32(SeqNo);
            writer.WriteInt32(Bytes);

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
            var tryseqNo = reader.ReadInt32();
            if (tryseqNo.IsError)
            {
                return ReadResult<IObject>.Move(tryseqNo);
            }
            SeqNo = tryseqNo.Value;
            var trybytes = reader.ReadInt32();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }
            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "rpc_answer_dropped";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RpcAnswerDropped
            {
                MsgId = MsgId,
                SeqNo = SeqNo,
                Bytes = Bytes
            };
            return newClonedObject;

        }
#nullable disable
    }
}