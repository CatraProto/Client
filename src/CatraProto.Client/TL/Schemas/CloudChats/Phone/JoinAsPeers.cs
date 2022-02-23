using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class JoinAsPeers : CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeersBase
    {
        public static int StaticConstructorId
        {
            get => -1343921601;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peers")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Peers { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public JoinAsPeers(IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> peers, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Peers = peers;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal JoinAsPeers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peers);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "phone.joinAsPeers";
        }
    }
}