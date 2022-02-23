using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TopPeerCategoryPeers : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase
    {
        public static int StaticConstructorId
        {
            get => -75283823;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("category")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("peers")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> Peers { get; set; }


    #nullable enable
        public TopPeerCategoryPeers(CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase category, int count, IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> peers)
        {
            Category = category;
            Count = count;
            Peers = peers;
        }
    #nullable disable
        internal TopPeerCategoryPeers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Category);
            writer.Write(Count);
            writer.Write(Peers);
        }

        public override void Deserialize(Reader reader)
        {
            Category = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase>();
            Count = reader.Read<int>();
            Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase>();
        }

        public override string ToString()
        {
            return "topPeerCategoryPeers";
        }
    }
}