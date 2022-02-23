using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class NotifyPeer : CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase
    {
        public static int StaticConstructorId
        {
            get => -1613493288;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }


    #nullable enable
        public NotifyPeer(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer)
        {
            Peer = peer;
        }
    #nullable disable
        internal NotifyPeer()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
        }

        public override string ToString()
        {
            return "notifyPeer";
        }
    }
}