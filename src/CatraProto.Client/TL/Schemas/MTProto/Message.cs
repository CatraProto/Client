using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class Message : CatraProto.Client.TL.Schemas.MTProto.MessageBase
    {
        public static int StaticConstructorId
        {
            get => 0;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("seqno")]
        public sealed override int Seqno { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override int Bytes { get; set; }

        [Newtonsoft.Json.JsonProperty("body")] public sealed override IObject Body { get; set; }


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

        public override void Serialize(Writer writer)
        {
            writer.Write(MsgId);
            writer.Write(Seqno);
            writer.Write(Bytes);
            writer.Write(Body);
        }

        public override void Deserialize(Reader reader)
        {
            MsgId = reader.Read<long>();
            Seqno = reader.Read<int>();
            Bytes = reader.Read<int>();
            Body = reader.Read<IObject>();
        }

        public override string ToString()
        {
            return "message";
        }
    }
}