using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPeerUserFromMessage : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
    {
        public static int StaticConstructorId
        {
            get => -1468331492;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


    #nullable enable
        public InputPeerUserFromMessage(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, long userId)
        {
            Peer = peer;
            MsgId = msgId;
            UserId = userId;
        }
    #nullable disable
        internal InputPeerUserFromMessage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(MsgId);
            writer.Write(UserId);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            MsgId = reader.Read<int>();
            UserId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputPeerUserFromMessage";
        }
    }
}