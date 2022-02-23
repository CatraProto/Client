using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SendScreenshotNotification : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -914493408;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public int ReplyToMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public long RandomId { get; set; }


    #nullable enable
        public SendScreenshotNotification(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int replyToMsgId, long randomId)
        {
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            RandomId = randomId;
        }
    #nullable disable

        internal SendScreenshotNotification()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(ReplyToMsgId);
            writer.Write(RandomId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            ReplyToMsgId = reader.Read<int>();
            RandomId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "messages.sendScreenshotNotification";
        }
    }
}