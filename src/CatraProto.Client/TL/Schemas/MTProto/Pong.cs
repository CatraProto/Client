using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class Pong : CatraProto.Client.TL.Schemas.MTProto.PongBase
    {
        public static int StaticConstructorId
        {
            get => 880243653;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(MsgId);
            writer.Write(PingId);
        }

        public override void Deserialize(Reader reader)
        {
            MsgId = reader.Read<long>();
            PingId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "pong";
        }
    }
}