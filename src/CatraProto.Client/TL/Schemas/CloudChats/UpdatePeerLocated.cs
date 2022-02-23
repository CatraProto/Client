using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePeerLocated : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1263546448;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peers")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase> Peers { get; set; }


    #nullable enable
        public UpdatePeerLocated(IList<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase> peers)
        {
            Peers = peers;
        }
    #nullable disable
        internal UpdatePeerLocated()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peers);
        }

        public override void Deserialize(Reader reader)
        {
            Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase>();
        }

        public override string ToString()
        {
            return "updatePeerLocated";
        }
    }
}