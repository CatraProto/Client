using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase
    {
        public static int StaticConstructorId
        {
            get => -386039788;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }


    #nullable enable
        public PeerBlocked(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, int date)
        {
            PeerId = peerId;
            Date = date;
        }
    #nullable disable
        internal PeerBlocked()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PeerId);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            Date = reader.Read<int>();
        }

        public override string ToString()
        {
            return "peerBlocked";
        }
    }
}