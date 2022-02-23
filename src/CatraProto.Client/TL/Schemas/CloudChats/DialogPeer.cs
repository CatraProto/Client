using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DialogPeer : CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase
    {
        public static int StaticConstructorId
        {
            get => -445792507;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }


    #nullable enable
        public DialogPeer(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer)
        {
            Peer = peer;
        }
    #nullable disable
        internal DialogPeer()
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
            return "dialogPeer";
        }
    }
}