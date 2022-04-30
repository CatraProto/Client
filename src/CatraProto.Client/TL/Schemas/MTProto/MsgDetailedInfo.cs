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
    public partial class MsgDetailedInfo : CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 661470918; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("answer_msg_id")]
        public sealed override long AnswerMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override int Bytes { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public sealed override int Status { get; set; }


#nullable enable
        public MsgDetailedInfo(long msgId, long answerMsgId, int bytes, int status)
        {
            MsgId = msgId;
            AnswerMsgId = answerMsgId;
            Bytes = bytes;
            Status = status;

        }
#nullable disable
        internal MsgDetailedInfo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(MsgId);
            writer.WriteInt64(AnswerMsgId);
            writer.WriteInt32(Bytes);
            writer.WriteInt32(Status);

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
            var tryanswerMsgId = reader.ReadInt64();
            if (tryanswerMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryanswerMsgId);
            }
            AnswerMsgId = tryanswerMsgId.Value;
            var trybytes = reader.ReadInt32();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }
            Bytes = trybytes.Value;
            var trystatus = reader.ReadInt32();
            if (trystatus.IsError)
            {
                return ReadResult<IObject>.Move(trystatus);
            }
            Status = trystatus.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "msg_detailed_info";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgDetailedInfo
            {
                MsgId = MsgId,
                AnswerMsgId = AnswerMsgId,
                Bytes = Bytes,
                Status = Status
            };
            return newClonedObject;

        }
#nullable disable
    }
}