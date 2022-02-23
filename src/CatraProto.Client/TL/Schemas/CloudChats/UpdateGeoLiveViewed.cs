using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateGeoLiveViewed : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -2027964103;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }


    #nullable enable
        public UpdateGeoLiveViewed(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int msgId)
        {
            Peer = peer;
            MsgId = msgId;
        }
    #nullable disable
        internal UpdateGeoLiveViewed()
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
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            MsgId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateGeoLiveViewed";
        }
    }
}