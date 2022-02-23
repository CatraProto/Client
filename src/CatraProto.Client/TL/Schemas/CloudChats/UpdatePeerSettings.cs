using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePeerSettings : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => 1786671974;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }


    #nullable enable
        public UpdatePeerSettings(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase settings)
        {
            Peer = peer;
            Settings = settings;
        }
    #nullable disable
        internal UpdatePeerSettings()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Settings);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();
        }

        public override string ToString()
        {
            return "updatePeerSettings";
        }
    }
}