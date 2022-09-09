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
    public partial class MsgNewDetailedInfo : CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2137147681; }

        [Newtonsoft.Json.JsonProperty("answer_msg_id")]
        public sealed override long AnswerMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override int Bytes { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public sealed override int Status { get; set; }


#nullable enable
        public MsgNewDetailedInfo(long answerMsgId, int bytes, int status)
        {
            AnswerMsgId = answerMsgId;
            Bytes = bytes;
            Status = status;
        }
#nullable disable
        internal MsgNewDetailedInfo()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(AnswerMsgId);
            writer.WriteInt32(Bytes);
            writer.WriteInt32(Status);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "msg_new_detailed_info";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgNewDetailedInfo();
            newClonedObject.AnswerMsgId = AnswerMsgId;
            newClonedObject.Bytes = Bytes;
            newClonedObject.Status = Status;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MsgNewDetailedInfo castedOther)
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