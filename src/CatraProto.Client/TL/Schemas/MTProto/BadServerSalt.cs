using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class BadServerSalt : CatraProto.Client.TL.Schemas.MTProto.BadMsgNotificationBase
    {
        public static int StaticConstructorId
        {
            get => -307542917;
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

        [Newtonsoft.Json.JsonProperty("new_server_salt")]
        public long NewServerSalt { get; set; }


    #nullable enable
        public BadServerSalt(long badMsgId, int badMsgSeqno, int errorCode, long newServerSalt)
        {
            BadMsgId = badMsgId;
            BadMsgSeqno = badMsgSeqno;
            ErrorCode = errorCode;
            NewServerSalt = newServerSalt;
        }
    #nullable disable
        internal BadServerSalt()
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
            writer.Write(NewServerSalt);
        }

        public override void Deserialize(Reader reader)
        {
            BadMsgId = reader.Read<long>();
            BadMsgSeqno = reader.Read<int>();
            ErrorCode = reader.Read<int>();
            NewServerSalt = reader.Read<long>();
        }

        public override string ToString()
        {
            return "bad_server_salt";
        }
    }
}