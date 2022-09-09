using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class MsgDetailedInfo : CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 661470918; }

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
            var newClonedObject = new MsgDetailedInfo();
            newClonedObject.MsgId = MsgId;
            newClonedObject.AnswerMsgId = AnswerMsgId;
            newClonedObject.Bytes = Bytes;
            newClonedObject.Status = Status;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MsgDetailedInfo castedOther)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (AnswerMsgId != castedOther.AnswerMsgId)
            {
                return true;
            }

            if (Bytes != castedOther.Bytes)
            {
                return true;
            }

            if (Status != castedOther.Status)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}