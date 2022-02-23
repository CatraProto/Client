using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class EditBanned : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1763259007;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Participant { get; set; }

        [Newtonsoft.Json.JsonProperty("banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase BannedRights { get; set; }


    #nullable enable
        public EditBanned(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights)
        {
            Channel = channel;
            Participant = participant;
            BannedRights = bannedRights;
        }
    #nullable disable

        internal EditBanned()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(Participant);
            writer.Write(BannedRights);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            BannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
        }

        public override string ToString()
        {
            return "channels.editBanned";
        }
    }
}