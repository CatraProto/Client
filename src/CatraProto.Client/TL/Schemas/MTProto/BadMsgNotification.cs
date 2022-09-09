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
    public partial class BadMsgNotification : CatraProto.Client.TL.Schemas.MTProto.BadMsgNotificationBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1477445615; }

        [Newtonsoft.Json.JsonProperty("bad_msg_id")]
        public sealed override long BadMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("bad_msg_seqno")]
        public sealed override int BadMsgSeqno { get; set; }

        [Newtonsoft.Json.JsonProperty("error_code")]
        public sealed override int ErrorCode { get; set; }


#nullable enable
        public BadMsgNotification(long badMsgId, int badMsgSeqno, int errorCode)
        {
            BadMsgId = badMsgId;
            BadMsgSeqno = badMsgSeqno;
            ErrorCode = errorCode;
        }
#nullable disable
        internal BadMsgNotification()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(BadMsgId);
            writer.WriteInt32(BadMsgSeqno);
            writer.WriteInt32(ErrorCode);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybadMsgId = reader.ReadInt64();
            if (trybadMsgId.IsError)
            {
                return ReadResult<IObject>.Move(trybadMsgId);
            }

            BadMsgId = trybadMsgId.Value;
            var trybadMsgSeqno = reader.ReadInt32();
            if (trybadMsgSeqno.IsError)
            {
                return ReadResult<IObject>.Move(trybadMsgSeqno);
            }

            BadMsgSeqno = trybadMsgSeqno.Value;
            var tryerrorCode = reader.ReadInt32();
            if (tryerrorCode.IsError)
            {
                return ReadResult<IObject>.Move(tryerrorCode);
            }

            ErrorCode = tryerrorCode.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "bad_msg_notification";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BadMsgNotification();
            newClonedObject.BadMsgId = BadMsgId;
            newClonedObject.BadMsgSeqno = BadMsgSeqno;
            newClonedObject.ErrorCode = ErrorCode;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BadMsgNotification castedOther)
            {
                return true;
            }

            if (BadMsgId != castedOther.BadMsgId)
            {
                return true;
            }

            if (BadMsgSeqno != castedOther.BadMsgSeqno)
            {
                return true;
            }

            if (ErrorCode != castedOther.ErrorCode)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}