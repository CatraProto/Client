using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class BadMsgNotification : CatraProto.Client.TL.Schemas.MTProto.BadMsgNotificationBase
    {
        public static int StaticConstructorId
        {
            get => -1477445615;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(BadMsgId);
            writer.Write(BadMsgSeqno);
            writer.Write(ErrorCode);
        }

        public override void Deserialize(Reader reader)
        {
            BadMsgId = reader.Read<long>();
            BadMsgSeqno = reader.Read<int>();
            ErrorCode = reader.Read<int>();
        }

        public override string ToString()
        {
            return "bad_msg_notification";
        }
    }
}