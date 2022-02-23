using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePendingJoinRequests : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => 1885586395;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("requests_pending")]
        public int RequestsPending { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_requesters")]
        public IList<long> RecentRequesters { get; set; }


    #nullable enable
        public UpdatePendingJoinRequests(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int requestsPending, IList<long> recentRequesters)
        {
            Peer = peer;
            RequestsPending = requestsPending;
            RecentRequesters = recentRequesters;
        }
    #nullable disable
        internal UpdatePendingJoinRequests()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(RequestsPending);
            writer.Write(RecentRequesters);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            RequestsPending = reader.Read<int>();
            RecentRequesters = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "updatePendingJoinRequests";
        }
    }
}