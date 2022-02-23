using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerLocated : CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase
    {
        public static int StaticConstructorId
        {
            get => -901375139;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("distance")]
        public int Distance { get; set; }


    #nullable enable
        public PeerLocated(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int expires, int distance)
        {
            Peer = peer;
            Expires = expires;
            Distance = distance;
        }
    #nullable disable
        internal PeerLocated()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Expires);
            writer.Write(Distance);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            Expires = reader.Read<int>();
            Distance = reader.Read<int>();
        }

        public override string ToString()
        {
            return "peerLocated";
        }
    }
}