using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotCommandScopePeer : CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase
    {
        public static int StaticConstructorId
        {
            get => -610432643;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }


    #nullable enable
        public BotCommandScopePeer(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
        {
            Peer = peer;
        }
    #nullable disable
        internal BotCommandScopePeer()
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
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
        }

        public override string ToString()
        {
            return "botCommandScopePeer";
        }
    }
}